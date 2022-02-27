using Ionic.Zlib;
using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Proxy;
using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.Core.Crypto;
using MinecraftLibrary.Core.IO;
using System.Net.Sockets;

namespace MinecraftLibrary.Client.Networking
{

    public class TcpClientSession : IDisposable, ITcpClientSession
    {
        private static readonly int ZERO_VARLENGTH = GetVarIntLength(0);
        public MinecraftStream NetStream { get; private set; }

        public string Host { get; set; }
        public int Port { get; set; }
        public ProxyInfo? Proxy { get; set; }


        public CancellationTokenSource Cancellation { get; private set; } = new();
        public int CompressionThreshold { get; set; } = 0;
        public IPacketRepository InputPackets { get; set; }

        public event Action<ITcpClientSession>? Connected;
        public event EventHandler<DisconnectedEventArgs>? Disconnected;
        public event EventHandler<PacketReceivedEventArgs>? PacketReceived;
        public event EventHandler<PacketSendEventArgs>? PacketSend;
        public event EventHandler<PacketSentEventArgs>? PacketSent;

        private TcpClient tcpClient;

        public void Connect()
        {
            tcpClient = new TcpClient(Host, Port);
            Connected?.Invoke(this);
            NetStream = new MinecraftStream(tcpClient.GetStream());
            ReadLoop();
        }
        private async Task<(int, MinecraftStream)> ReadNextPacketAsync()
        {
            int len = await NetStream.ReadVarIntAsync();
            Console.WriteLine("len " + len);
            byte[] receivedata = new byte[len];
            await NetStream.ReadAsync(receivedata.AsMemory(0, len));
            int id = 0;
            var ms = new MinecraftStream(receivedata);
            if (CompressionThreshold > 0)
            {
                int sizeUncompressed = ms.ReadVarInt();
                if (sizeUncompressed != 0)
                {
                    ZlibStream zlibStream = new ZlibStream(ms.BaseStream, CompressionMode.Decompress);
                    ms.BaseStream = zlibStream;
                }

            }
            id = ms.ReadVarInt();
            return (id, ms);
        }
        private async void ReadLoop()
        {
            try
            {
                while (tcpClient.Connected && !Cancellation.IsCancellationRequested)
                {
                    (int id, MinecraftStream dataStream) = await ReadNextPacketAsync();
                    IPacket packet = null;
                    if (InputPackets.TryGetPacket(id, out packet))
                    {
                        packet.Read(dataStream);
                        PacketReceived?.Invoke(this, new PacketReceivedEventArgs(id, packet));
                    }
                }
            }
            catch (SocketException e)
            {
                Disconnected?.Invoke(this, new DisconnectedEventArgs("Ошибка при чтении", e));
            }
            catch (Exception e)
            {

            }
            finally
            {
                Cancellation.Cancel();
            }
        }


        public void Disconnect()
        {
            Cancellation.Cancel();
        }
        public void SendPacket(IPacket packet, int id)
        {
            ArgumentNullException.ThrowIfNull(packet, nameof(packet));
            PacketSend?.Invoke(this, new PacketSendEventArgs(packet));
            if (CompressionThreshold > 0)
            {
                using (MinecraftStream packetStream = new MinecraftStream())
                {
                    packetStream.WriteVarInt(id);
                    packet.Write(packetStream);

                    int to_Packetlength = (int)packetStream.Length;

                    if (to_Packetlength >= CompressionThreshold)
                    {
                        SendLongPacket(packetStream, to_Packetlength);
                    }
                    else
                    {
                        SendShortPacket(packetStream);
                    }
                }
            }
            else
            {
                SendPacketWithoutCompression(packet, id);
            }
            PacketSent?.Invoke(this, new PacketSentEventArgs(packet));

        }
        private void SendPacketWithoutCompression(IPacket packet, int id)
        {
            Console.WriteLine("dis");
            using (MinecraftStream packetStream = new MinecraftStream())
            {
                packet.Write(packetStream);
                int Packetlength = (int)packetStream.Length;

                NetStream.Lock.Wait();
                NetStream.WriteVarInt(GetVarIntLength(id) + Packetlength);
                NetStream.WriteVarInt(id);
                packetStream.Position = 0;
                packetStream.CopyTo(NetStream);
                NetStream.Lock.Release();
            }
        }

        private void SendLongPacket(MinecraftStream packetStream, int to_Packetlength)
        {
            Console.WriteLine("Long");
            using (MemoryStream memstream = new MemoryStream())
            {
                using (ZlibStream stream = new ZlibStream(memstream, CompressionMode.Compress))
                {
                    packetStream.CopyTo(stream);
                }
                packetStream.BaseStream = memstream;
            }
            int fullSize = (int)packetStream.Length + GetVarIntLength(to_Packetlength);
            NetStream.WriteVarInt(fullSize);
            NetStream.WriteVarInt(to_Packetlength);
            packetStream.Position = 0;
            packetStream.CopyTo(NetStream);
        }
        private void SendShortPacket(MinecraftStream packetStream)
        {
            Console.WriteLine("short");
            int fullSize = (int)packetStream.Length + ZERO_VARLENGTH;
            NetStream.WriteVarInt(fullSize);
            NetStream.WriteVarInt(0);
            packetStream.Position = 0;
            packetStream.CopyTo(NetStream);
        }


        public void SwitchEncryption(byte[] key)
        {
            NetStream.Lock.Wait();
            NetStream = new AesStream(tcpClient.GetStream(), key);
        }



        public void Dispose()
        {
            Cancellation.Dispose();
            tcpClient?.Dispose();
            NetStream?.Dispose();

            Connected = null;
            Disconnected = null;

            tcpClient = null;
            NetStream = null;
            Cancellation = null;

            GC.SuppressFinalize(this);
        }

        private static int GetVarIntLength(int val)
        {
            int amount = 0;
            do
            {
                val >>= 7;
                amount++;
            } while (val != 0);

            return amount;
        }
        ~TcpClientSession()
        {
            Dispose();
        }
    }

}
