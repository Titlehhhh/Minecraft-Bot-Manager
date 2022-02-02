using MinecraftLibrary.API.Helpers;
using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Crypto;
using MinecraftLibrary.API.Networking.Events;
using MinecraftLibrary.API.Networking.Proxy;
using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Events;
using MinecraftLibrary.API.Protocol.Helpres;
using MinecraftLibrary.Networking.Session.Compression;
using MinecraftLibrary.Networking.Session.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace MinecraftLibrary.Networking.Session
{
    public sealed class TcpClientSession : ITcpClientSession, IPacketReader
    {

        private TcpClient tcpClient;
        private IPEndPoint host;

        private IAesStream cryptoStream;
        private ProxyInfo proxyInfo;

        private bool encrypted;
        private bool Disconnected;
        private bool isProxy;
        private int compressionThreshold;
        private int protocolVersion;

        public bool IsConnected => tcpClient != null && tcpClient.Connected && !this.Disconnected;

        public int CompressionThreshold
        {
            get => compressionThreshold;
            set
            {
                compressionThreshold = value;
                ComperssionThresholdChanged?.Invoke(this, value);
            }
        }

        public IPEndPoint EndPoint => host;

        public ProxyInfo Proxy => proxyInfo;

        public bool IsEncryption => encrypted;

        public TcpClient Tcp => tcpClient;

        public IAesStream AesStream => cryptoStream;

        public bool IsProxyUsed => isProxy;

        public Dictionary<Type, int> RegisteredOutputPakets { get; set; }
        public Dictionary<int, Type> RegisteredInputPakets { get; set; }



        public int ProtocolVersion
        {
            get => protocolVersion;
            set
            {
                if (value <= 0)
                    throw new InvalidOperationException("Неверная версия протокола");
                protocolVersion = value;
            }
        }

        public event EventHandler<ConnectedEventArgs> Connected;
        public event EventHandler<DisconnectedEventArgs> DisconnectedEvent;
        public event EventHandler<PacketReceivedEventArgs> DataReceivedEvent;
        public event EventHandler<byte[]> EncryptionEnabledChanged;
        public event EventHandler<int> ComperssionThresholdChanged;
        public event EventHandler<ByteBlock> DataSendChanged;
        public event EventHandler<ByteBlock> DataSentChanged;
        public event EventHandler<PacketProcessedEventArgs> PacketProcessedEvent;
        public event EventHandler<PacketSendEventArgs> PacketSendEvent;
        public event EventHandler<PacketSentEventArgs> PacketSentEvent;

        public TcpClientSession(string host, int port)
        {
            IPAddress address;
            if (!IPAddress.TryParse(host, out address))
                address = Dns.GetHostEntry(host).AddressList[0];
            this.host = new IPEndPoint(address, port);
        }
        public TcpClientSession(string host, int port, ProxyInfo proxy) : this(host, port)
        {
            this.isProxy = true;
            proxyInfo = proxy;
        }
        public void Connect()
        {
            if (this.IsConnected || Disconnected)
                return;

            try
            {
                tcpClient = new TcpClient();
                tcpClient.ReceiveBufferSize = 1024 * 1024;
                tcpClient.ReceiveTimeout = 30 * 1000;
                // tcpClient.SendBufferSize = 1024 * 1024;
                //  tcpClient.SendTimeout = 30 * 1000;

                tcpClient.Connect(EndPoint);
                Connected?.Invoke(this, new ConnectedEventArgs());
                ReadLoop();
            }
            catch (Exception e)
            {
                DisconnectedEvent?.Invoke(this, new DisconnectedEventArgs("Ошибка подключения", e));
            }
        }
        private void ReadLoop()
        {
            Task.Run((Action)(() =>
            {
                try
                {
                    while (IsConnected && !this.Disconnected)
                    {
                        ByteBlock byteBlock = ReadNextByteBlock();                       
                        DataReceivedEvent?.Invoke(this, new PacketReceivedEventArgs(byteBlock));
                        ProcessPacket(byteBlock);
                    }
                }
                catch (Exception e)
                {
                    if (!this.Disconnected)
                        DisconnectedEvent?.Invoke(this, new DisconnectedEventArgs("При считывании пакета произошла ошибка", e));
                }
            }));
        }

        private void ProcessPacket(ByteBlock block)
        {
            int id = block.ID;
            byte[] data = block.Data;
            if (RegisteredInputPakets.ContainsKey(id))
            {
                IPacket packet = CreateInstance(RegisteredInputPakets[id]);
                using (MinecraftStream ms = new MinecraftStream(new MemoryStream(data), ProtocolVersion))
                {
                    packet.Read(ms, ProtocolVersion);
                }
                PacketProcessedEvent?.Invoke(this, new PacketProcessedEventArgs(packet));
            }
        }

        public void Disconnect()
        {
            if (Disconnected || tcpClient == null)
                return;
            Disconnected = true;

            tcpClient.Close();
            Dispose();

        }

        public void Dispose()
        {

        }

        public void EnabledEncryption(byte[] key)
        {
            if (encrypted)
                throw new InvalidOperationException("Шифрование уже включено");
            cryptoStream = CryptoHandler.getAesStream(tcpClient.GetStream(), key);
            encrypted = true;
            EncryptionEnabledChanged?.Invoke(this, key);

        }

        private ByteBlock ReadNextByteBlock()
        {
            int size = ReadNextVarIntRAW();

            byte[] rawpacket = ReadDataRAW(size);
            int id = -1;

            using (MemoryStream ms = new MemoryStream(rawpacket))
            {
                if (CompressionThreshold > 0)
                {
                    int sizeUncompressed = ms.ReadVarInt();
                    if (sizeUncompressed != 0) // != 0 means compressed, let's decompress
                    {
                        byte[] unCompress = ZlibUtils.Decompress(rawpacket, sizeUncompressed);
                        rawpacket = unCompress;
                    }
                }
                id = ms.ReadVarInt();
            }
            return new ByteBlock(id, rawpacket);
        }

        public void Send(ByteBlock data)
        {
            DataSendChanged?.Invoke(this, data);
            try
            {
                byte[] sendData = DataTypes.ConcatBytes(DataTypes.GetVarInt(data.ID), data.Data);
                Send(sendData);
                DataSentChanged?.Invoke(this, data);
            }
            catch (Exception e)
            {
                if (!Disconnected)
                    DisconnectedEvent?.Invoke(this, new DisconnectedEventArgs("Ошибка при отправке", e));
            }
        }

        public void Send(byte[] data)
        {

            if (CompressionThreshold > 0)
            {
                if (data.Length >= CompressionThreshold)
                {
                    byte[] compressed_packet = ZlibUtils.Compress(data);
                    data = DataTypes.ConcatBytes(DataTypes.GetVarInt(data.Length), compressed_packet);
                }
                else
                {
                    byte[] uncompressed_length = DataTypes.GetVarInt(0);
                    data = DataTypes.ConcatBytes(uncompressed_length, data);
                }
            }
            SendDataRAW(DataTypes.ConcatBytes(DataTypes.GetVarInt(data.Length), data));

        }
        private void SendDataRAW(byte[] buffer)
        {
            if (encrypted)
            {
                cryptoStream.Write(buffer, 0, buffer.Length);
            }
            else tcpClient.Client.Send(buffer);
        }
        private int ReadNextVarIntRAW()
        {
            int i = 0;
            int j = 0;
            int k = 0;
            while (true)
            {
                k = ReadDataRAW(1)[0];
                i |= (k & 0x7F) << j++ * 7;
                if (j > 5) throw new OverflowException("VarInt too big");
                if ((k & 0x80) != 128) break;
            }
            return i;
        }
        private byte[] ReadDataRAW(int length)
        {
            if (length > 0)
            {
                byte[] cache = new byte[length];
                Receive(cache, 0, length, SocketFlags.None);
                return cache;
            }
            return new byte[] { };
        }

        private void Receive(byte[] buffer, int start, int offset, SocketFlags f)
        {
            if (tcpClient != null)
            {
                if (tcpClient.Client != null)
                {
                    int read = 0;
                    while (read < offset)
                    {
                        if (encrypted)
                        {
                            read += cryptoStream.Read(buffer, start + read, offset - read);
                        }
                        else read += tcpClient.Client.Receive(buffer, start + read, offset - read, f);
                    }
                }
            }
        }

        private static IPacket CreateInstance(Type t)
        {
            return (IPacket)Activator.CreateInstance(t);
        }

        public void RegisterPacketInput(int id, Type t)
        {
            RegisteredInputPakets.Add(id, t);
        }

        public void RegisterPacketOutput(int id, Type t)
        {
            RegisteredOutputPakets.Add(t, id);
        }

        public void SendPacket(IPacket packet)
        {
            if (packet is null)
                throw new ArgumentNullException(nameof(packet));
            Type t = packet.GetType();
            if (RegisteredOutputPakets.ContainsKey(t))
            {
                int id = RegisteredOutputPakets[t];

                MemoryStream ms = new MemoryStream();
                using (MinecraftStream mcs = new MinecraftStream(ms, ProtocolVersion))
                {
                    packet.Write(mcs, ProtocolVersion);
                }
                ByteBlock byteBlock = new ByteBlock(id, ms.ToArray());
                PacketSendEvent?.Invoke(this, new PacketSendEventArgs(packet));
                this.Send(byteBlock);
                PacketSentEvent?.Invoke(this, new PacketSentEventArgs(packet));

            }
        }

        public bool UnRegisterPacketInput(int id)
        {
            return RegisteredInputPakets.Remove(id);
        }

        public bool UnRegisterPacketOutput(Type t)
        {
            return RegisteredOutputPakets.Remove(t);
        }
    }
    internal static class MemeoryStreamExt
    {
        internal static int ReadVarInt(this MemoryStream memory)
        {
            int i = 0;
            int j = 0;
            int k = 0;
            while (true)
            {
                k = memory.ReadByte();
                i |= (k & 0x7F) << j++ * 7;
                if (j > 5) throw new OverflowException("VarInt too big");
                if ((k & 0x80) != 128) break;
            }
            return i;
        }
    }
}
