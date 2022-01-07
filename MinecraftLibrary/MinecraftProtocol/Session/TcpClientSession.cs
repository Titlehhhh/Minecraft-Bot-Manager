
using MinecraftLibrary.MinecraftProtocol.Packets.Client.Login;
using MinecraftLibrary.MinecraftProtocol.Packets.HandShake;
using MinecraftProtocol;
using MinecraftProtocol.IO;
using MinecraftProtocol.IO.Stream;
using MinecraftProtocol.Packets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using MinecraftLibrary.MinecraftProtocol.IO.Stream;
using MinecraftLibrary.MinecraftProtocol.Packets.Server.Login;
using MinecraftClient.Crypto;
using System.Diagnostics;
using System.Threading;
using MinecraftLibrary.MinecraftProtocol.Packets.Server.Game;
using MinecraftLibrary.MinecraftProtocol.Packets.Client.Game;
using Ionic.Zlib;
using MinecraftLibrary.MinecraftProtocol.PacketPalletes;
using StarkSoftProxy;
using Starksoft.Net.Proxy;
using System.Reflection;
using System.Net;
using System.IO;

namespace MinecraftLibrary
{
    public delegate void ReadPacket(object sender, int id, byte[] data);
    public class TcpClientSession
    {


        SocketWrapper socket;

        public SubProtocol SetSubProtocol
        {
            set
            {
                if (value == SubProtocol.LOGIN)
                {
                    RegisterLoginPackets();
                }
                else if (value == SubProtocol.HANDSHAKE)
                {
                    RegisterHandShakePackets();
                }
                else
                {
                    RegisterGamePackets();
                    LoginSuccesChanged?.Invoke();
                }

            }
        }

        private Dictionary<Type, int> PacketsOut = new Dictionary<Type, int>();
        private Dictionary<int, Type> PacketsIn = new Dictionary<int, Type>();


        private string Host;
        private int Port;
        private string Nickname;
        private int protocolversion;
        private string proxyHost;
        private int proxyPort;
        private ProxyType proxyType;


        public event Connected ConnectedChanged;

        public event PacketReceive PacketReceiveChanged;

        public event PacketSent PacketSentChanged;

        public event PacketSend PacketSendChanged;

        public event Disconnect DisconnectChanged;
        public event LoginSucces LoginSuccesChanged;

        public event ReadPacket ReadPacketChanged;

        private TcpClient tcpClient;

        private PacketPallete packetPallete;

        private int compression_treshold = 0;
        private bool need = false;

        public TcpClientSession(string host, int port, string username, int version)
        {
            Host = host;
            Port = port;
            Nickname = username;
            protocolversion = version;
        }
        public TcpClientSession(string host, int port, string proxyHost, int proxyPort, ProxyType proxyType, string username, int version)
        {
            Host = host;
            Port = port;
            Nickname = username;
            protocolversion = version;

            this.proxyHost = proxyHost;
            this.proxyPort = proxyPort;
            this.proxyType = proxyType;

        }
        public bool Connect()
        {
            Disconect = false;
            if (socket != null)
            {
                if (socket.IsConnected())
                {
                    return false;
                }
                else
                {
                    tcpClient.Dispose();
                }
            }
            try
            {
                need = true;

                if (proxyType == ProxyType.None)
                {
                    tcpClient = new TcpClient();
                    tcpClient.ReceiveBufferSize = 1024 * 1024;
                    tcpClient.ReceiveTimeout = 30000;
                    tcpClient.Connect(Host, Port);
                    ConnectedChanged?.Invoke();
                }
                else
                {
                    Debug.WriteLine($"StartProxy: {proxyHost} {proxyPort} {proxyType}");
                    ProxyClientFactory factory = new ProxyClientFactory();
                    tcpClient = factory.CreateProxyClient(proxyType, proxyHost, proxyPort).CreateConnection(Host, Port);

                }

                if (protocolversion == MinecraftConstans.MC1122Version)
                    packetPallete = new Packets1_12_2();
                else if (protocolversion == MinecraftConstans.MC1165Version)
                    packetPallete = new Packets1_16_5();

                socket = new SocketWrapper(tcpClient);


                SetSubProtocol = SubProtocol.HANDSHAKE;

                HandShakePacket handShake = new HandShakePacket(HandShakeIntent.LOGIN, protocolversion, Port, Host);
                SendPacket(handShake);
                SetSubProtocol = SubProtocol.LOGIN;
                LoginStartPacket loginStart = new LoginStartPacket(Nickname);
                SendPacket(loginStart);
                while (true)
                {
                    Tuple<int, byte[]> packet = ReadNextPacket();
                    Debug.WriteLine("Login: " + packet.Item1);
                    if (packet.Item1 == 1)
                    {
                        StreamNetInput input = new StreamNetInput(new Queue<byte>(packet.Item2), protocolversion);
                        EncryptionRequestPacket encryptionRequest = new EncryptionRequestPacket();
                        encryptionRequest.Read(input, protocolversion);
                        System.Security.Cryptography.RSACryptoServiceProvider RSAService = CryptoHandler.DecodeRSAPublicKey(encryptionRequest.sharedkey);
                        byte[] secretKey = CryptoHandler.GenerateAESPrivateKey();
                        byte[] key_enc = StreamNetOutput.GetArray(RSAService.Encrypt(secretKey, false), protocolversion);
                        byte[] token_enc = StreamNetOutput.GetArray(RSAService.Encrypt(encryptionRequest.verifytoken, false), protocolversion);

                        SendPacket(0x01, StreamNetOutput.ConcatBytes(key_enc, token_enc));
                        socket.SwitchToEncrypted(secretKey);
                    }
                    else if (packet.Item1 == 3)
                    {
                        if (protocolversion >= MinecraftConstans.MC18Version)
                            compression_treshold = new StreamNetInput(new Queue<byte>(packet.Item2), protocolversion).ReadNextVarInt();

                    }
                    else if (packet.Item1 == 2)
                    {
                        SetSubProtocol = SubProtocol.GAME;
                        StartUpdate();

                        return true;
                    }
                    else if (packet.Item1 == 0)
                    {
                        StreamNetInput netInput = new StreamNetInput(new Queue<byte>(packet.Item2), protocolversion);
                        if (!Disconect)
                            DisconnectChanged?.Invoke(MinecraftProtocol.DisconnectReason.LoginRejected, netInput.ReadNextString());
                        return false;
                    }

                }




            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
                if (!Disconect)
                    DisconnectChanged?.Invoke(MinecraftProtocol.DisconnectReason.ConnectionLost, e.ToString());
                return false;
            }
        }
        private bool Disconect = false;
        public void Disconnect()
        {
            try
            {
                Disconect = true;
                need = false;
                tcpClient?.Close();
                tcpClient?.Dispose();
            }
            catch
            {

                tcpClient?.Dispose();

            }
        }

        private void SendLoginPluginResponse(int messageId, bool understood, byte[] data)
        {
            try
            {
                SendPacket(0x02, StreamNetOutput.ConcatBytes(StreamNetOutput.GetVarInt(messageId), StreamNetOutput.GetBool(understood), data));

            }
            catch
            {

            }
        }
        public void StartUpdate()
        {
            Task.Run(() =>
            {
                try
                {

                    while (need)
                    {
                        if (Disconect)
                            return;

                        Tuple<int, byte[]> packet = ReadNextPacket();
                        ReadPacketChanged?.Invoke(this, packet.Item1, packet.Item2);
                        try
                        {
                            ServerPacket pac = GetPacketIn(packet.Item1);

                            pac.Read(new StreamNetInput(new Queue<byte>(packet.Item2), protocolversion), protocolversion);
                            if (pac.GetType() == typeof(ServerDisconnectPacket))
                            {
                                var dis = pac as ServerDisconnectPacket;
                                if (!Disconect)
                                    DisconnectChanged?.Invoke(MinecraftProtocol.DisconnectReason.InGameKick, dis.DisconnectMessage);
                                Disconnect();
                                break;
                            }
                            PacketReceiveChanged?.Invoke(pac);
                        }
                        catch (Exception packetRead)
                        {
                            Console.WriteLine("При считывании пакета произошло исключение:\n" + packetRead);
                        }


                    }
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e);
                    if (!Disconect)
                        DisconnectChanged?.Invoke(MinecraftProtocol.DisconnectReason.ConnectionLost, e.ToString());

                }
            });
        }
        public void SendPacket(ClientPacket packet)
        {
            if (socket != null)
            {
                if (socket.IsConnected())
                {

                    try
                    {
                        // Debug.WriteLine(PacketsOut[packet.GetType()]);
                        StreamNetOutput output = new StreamNetOutput(protocolversion);
                        packet.Write(output, protocolversion);
                        byte[] the_packet = StreamNetOutput.ConcatBytes(StreamNetOutput.GetVarInt(PacketsOut[packet.GetType()]), output.Data);
                        if (compression_treshold > 0) //Compression enabled?
                        {
                            if (the_packet.Length >= compression_treshold) //Packet long enough for compressing?
                            {
                                byte[] compressed_packet = ZlibUtils.Compress(the_packet);
                                the_packet = StreamNetOutput.ConcatBytes(StreamNetOutput.GetVarInt(the_packet.Length), compressed_packet);
                            }
                            else
                            {
                                byte[] uncompressed_length = StreamNetOutput.GetVarInt(0); //Not compressed (short packet)
                                the_packet = StreamNetOutput.ConcatBytes(uncompressed_length, the_packet);
                            }
                        }
                        output = new StreamNetOutput(protocolversion);
                        output.WriteArray(the_packet);

                        PacketSendChanged?.Invoke(packet);
                        socket.SendDataRAW(output.Data);
                        PacketSentChanged?.Invoke(packet);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.ToString());
                        if (!Disconect)
                            DisconnectChanged?.Invoke(MinecraftProtocol.DisconnectReason.ConnectionLost, e.ToString());
                    }
                }
            }
        }
        private void SendPacket(int packetID, IEnumerable<byte> packetData)
        {

            //The inner packet
            byte[] the_packet = StreamNetOutput.ConcatBytes(StreamNetOutput.GetVarInt(packetID), packetData.ToArray());

            if (compression_treshold > 0) //Compression enabled?
            {
                if (the_packet.Length >= compression_treshold) //Packet long enough for compressing?
                {
                    byte[] compressed_packet = ZlibUtils.Compress(the_packet);
                    the_packet = StreamNetOutput.ConcatBytes(StreamNetOutput.GetVarInt(the_packet.Length), compressed_packet);
                }
                else
                {
                    byte[] uncompressed_length = StreamNetOutput.GetVarInt(0); //Not compressed (short packet)
                    the_packet = StreamNetOutput.ConcatBytes(uncompressed_length, the_packet);
                }
            }
            socket.SendDataRAW(StreamNetOutput.ConcatBytes(StreamNetOutput.GetVarInt(the_packet.Length), the_packet));
        }
        #region Callbacks

        private Tuple<int, byte[]> ReadNextPacket()
        {

            int size = ReadNextVarIntRAW();

            byte[] rawpacket = socket.ReadDataRAW(size);

            StreamNetInput input = new StreamNetInput(new Queue<byte>(rawpacket), protocolversion);

            if (protocolversion >= MinecraftConstans.MC18Version
                && compression_treshold > 0)
            {
                int sizeUncompressed = input.ReadNextVarInt();


                if (sizeUncompressed != 0) // != 0 means compressed, let's decompress
                {
                    byte[] unCompress = ZlibUtils.Decompress(input.Data, sizeUncompressed);
                    input = new StreamNetInput(new Queue<byte>(unCompress), protocolversion);

                }
            }

            int id = input.ReadNextVarInt();

            return new Tuple<int, byte[]>(id, input.Data);

        }


        private void RegisterHandShakePackets()
        {
            PacketsIn.Clear();
            PacketsOut.Clear();
            PacketsOut.Add(typeof(HandShakePacket), 0x00);
        }
        private void RegisterLoginPackets()
        {
            PacketsIn.Clear();
            PacketsOut.Clear();
            PacketsIn.Add(0x01, typeof(EncryptionRequestPacket));
            PacketsOut.Add(typeof(EncryptionResponsePacket), 0x01);
            PacketsOut.Add(typeof(LoginStartPacket), 0x00);
            PacketsIn.Add(0x02, typeof(LoginSuccesPacket));
        }
        private void RegisterGamePackets()
        {
            PacketsIn.Clear();
            PacketsOut.Clear();

            PacketsOut = packetPallete.GetOutPackets();
            PacketsIn = packetPallete.GetInPackets();
        }
        public ServerPacket GetPacketIn(int id)
        {
            return (ServerPacket)Activator.CreateInstance(PacketsIn[id]);
        }

        private int ReadNextVarIntRAW()
        {
            int i = 0;
            int j = 0;
            int k = 0;
            while (true)
            {
                k = socket.ReadDataRAW(1)[0];
                i |= (k & 0x7F) << j++ * 7;
                if (j > 5) throw new OverflowException("VarInt too big");
                if ((k & 0x80) != 128) break;
            }
            return i;
        }
        #endregion
    }
    public static class ProxyHandler
    {
        public static TcpClient ProxyTcpClient(string targetHost, int targetPort, string httpProxyHost, int httpProxyPort, string proxyUserName, string proxyPassword)
        {
            const BindingFlags Flags = BindingFlags.NonPublic | BindingFlags.Instance;
            Uri proxyUri = new UriBuilder
            {
                Scheme = Uri.UriSchemeHttp,
                Host = httpProxyHost,
                Port = httpProxyPort
            }.Uri;
            Uri targetUri = new UriBuilder
            {
                Scheme = Uri.UriSchemeHttp,
                Host = targetHost,
                Port = targetPort
            }.Uri;

            WebProxy webProxy = new WebProxy($"http://{httpProxyHost}:{httpProxyPort}/");
            //webProxy.Credentials = new NetworkCredential(proxyUserName, proxyPassword);
            WebRequest request = WebRequest.Create(targetUri);
            request.Proxy = webProxy;
            request.Method = "CONNECT";
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    Stream responseStream = response.GetResponseStream();
                    Type responseType = responseStream.GetType();
                    PropertyInfo connectionProperty = responseType.GetProperty("Connection", Flags);
                    var connection = connectionProperty.GetValue(responseStream, null);
                    Type connectionType = connection.GetType();
                    PropertyInfo networkStreamProperty = connectionType.GetProperty("NetworkStream", Flags);
                    NetworkStream networkStream = (NetworkStream)networkStreamProperty.GetValue(connection, null);
                    Type nsType = networkStream.GetType();
                    PropertyInfo socketProperty = nsType.GetProperty("Socket", Flags);
                    Socket socket = (Socket)socketProperty.GetValue(networkStream, null);

                    return new TcpClient { Client = socket };
                }
                else
                {
                    throw new Exception(response.StatusCode.ToString());
                }
            }
        }
    }
    class SocketWrapper
    {
        TcpClient c;
        IAesStream s;
        bool encrypted = false;

        /// <summary>
        /// Initialize a new SocketWrapper
        /// </summary>
        /// <param name="client">TcpClient connected to the server</param>
        public SocketWrapper(TcpClient client)
        {
            this.c = client;
        }

        /// <summary>
        /// Check if the socket is still connected
        /// </summary>
        /// <returns>TRUE if still connected</returns>
        /// <remarks>Silently dropped connection can only be detected by attempting to read/write data</remarks>
        public bool IsConnected()
        {
            return c.Client != null && c.Connected;
        }

        /// <summary>
        /// Check if the socket has data available to read
        /// </summary>
        /// <returns>TRUE if data is available to read</returns>
        public bool HasDataAvailable()
        {
            return c.Client.Available > 0;
        }

        /// <summary>
        /// Switch network reading/writing to an encrypted stream
        /// </summary>
        /// <param name="secretKey">AES secret key</param>
        public void SwitchToEncrypted(byte[] secretKey)
        {
            if (encrypted)
                throw new InvalidOperationException("Stream is already encrypted!?");
            this.s = CryptoHandler.getAesStream(c.GetStream(), secretKey);
            this.encrypted = true;
        }

        /// <summary>
        /// Network reading method. Read bytes from the socket or encrypted socket.
        /// </summary>
        private void Receive(byte[] buffer, int start, int offset, SocketFlags f)
        {
            if (c != null)
            {
                if (c.Client != null)
                {
                    int read = 0;
                    while (read < offset)
                    {
                        if (encrypted)
                        {
                            read += s.Read(buffer, start + read, offset - read);
                        }
                        else read += c.Client.Receive(buffer, start + read, offset - read, f);
                    }
                }
            }
        }

        /// <summary>
        /// Read some data from the server.
        /// </summary>
        /// <param name="length">Amount of bytes to read</param>
        /// <returns>The data read from the network as an array</returns>
        public byte[] ReadDataRAW(int length)
        {
            if (length > 0)
            {
                byte[] cache = new byte[length];
                Receive(cache, 0, length, SocketFlags.None);
                return cache;
            }
            return new byte[] { };
        }

        /// <summary>
        /// Send raw data to the server.
        /// </summary>
        /// <param name="buffer">data to send</param>
        public void SendDataRAW(byte[] buffer)
        {
            if (encrypted)
            {
                s.Write(buffer, 0, buffer.Length);
            }
            else c.Client.Send(buffer);
        }

        /// <summary>
        /// Disconnect from the server
        /// </summary>
        public void Disconnect()
        {
            try
            {
                c.Close();
            }
            catch (SocketException) { }
            catch (System.IO.IOException) { }
            catch (NullReferenceException) { }
            catch (ObjectDisposedException) { }
        }
    }
    public static class ZlibUtils
    {
        /// <summary>
        /// Compress a byte array into another bytes array using Zlib compression
        /// </summary>
        /// <param name="to_compress">Data to compress</param>
        /// <returns>Compressed data as a byte array</returns>
        public static byte[] Compress(byte[] to_compress)
        {
            byte[] data;
            using (System.IO.MemoryStream memstream = new System.IO.MemoryStream())
            {
                using (ZlibStream stream = new ZlibStream(memstream, CompressionMode.Compress))
                {
                    stream.Write(to_compress, 0, to_compress.Length);
                }
                data = memstream.ToArray();
            }
            return data;
        }

        /// <summary>
        /// Decompress a byte array into another byte array of the specified size
        /// </summary>
        /// <param name="to_decompress">Data to decompress</param>
        /// <param name="size_uncompressed">Size of the data once decompressed</param>
        /// <returns>Decompressed data as a byte array</returns>
        public static byte[] Decompress(byte[] to_decompress, int size_uncompressed)
        {
            ZlibStream stream = new ZlibStream(new System.IO.MemoryStream(to_decompress, false), CompressionMode.Decompress);
            byte[] packetData_decompressed = new byte[size_uncompressed];
            stream.Read(packetData_decompressed, 0, size_uncompressed);
            stream.Close();
            return packetData_decompressed;
        }

        /// <summary>
        /// Decompress a byte array into another byte array of a potentially unlimited size (!)
        /// </summary>
        /// <param name="to_decompress">Data to decompress</param>
        /// <returns>Decompressed data as byte array</returns>
        public static byte[] Decompress(byte[] to_decompress)
        {
            ZlibStream stream = new ZlibStream(new System.IO.MemoryStream(to_decompress, false), CompressionMode.Decompress);
            byte[] buffer = new byte[16 * 1024];
            using (System.IO.MemoryStream decompressedBuffer = new System.IO.MemoryStream())
            {
                int read;
                while ((read = stream.Read(buffer, 0, buffer.Length)) > 0)
                    decompressedBuffer.Write(buffer, 0, read);
                return decompressedBuffer.ToArray();
            }
        }
    }

}
