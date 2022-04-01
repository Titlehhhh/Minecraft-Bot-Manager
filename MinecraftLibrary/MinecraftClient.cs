using MinecraftLibrary.API;
using MinecraftLibrary.API.Crypto;
using MinecraftLibrary.API.IO;
using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.Exceptions;
using MinecraftLibrary.Geometry;
using MinecraftLibrary.Protocol;
using ProtocolLib754;
using ProtocolLib754.Packets.Client;
using ProtocolLib754.Packets.Server;
using System.ComponentModel;
using System.Net.Sockets;
using System.Runtime.CompilerServices;

namespace MinecraftLibrary
{


    public class MinecraftClient : IDisposable, INotifyPropertyChanged
    {
        public static void Debug(string msg)
        {

        }
        private TcpClient tcpClient;
        private NetworkMinecraftStream NetMcStream;
        private PacketReaderWriter packetReaderWriter;
        public MinecraftClient()
        {

        }

        public bool IsConnected => tcpClient != null && tcpClient.Connected;

        public bool IsAuth
        {
            get => isAuth;
            set
            {
                if (!IsConnected)
                    isAuth = value;
                throw new NotImplementedException("Нельзя изменять свойсва во время работы");
            }
        }
        public string Nickname
        {
            get => nickname;
            set
            {
                if (!IsConnected)
                    nickname = value;
                throw new NotImplementedException("Нельзя изменять свойсва во время работы");
            }
        }
        public string Password
        {
            get => password;
            set
            {
                if (!IsConnected)
                    password = value;
                throw new NotImplementedException("Нельзя изменять свойсва во время работы");
            }
        }
        public string Host
        {
            get => host;
            set
            {
                host = value;
                throw new NotImplementedException("Нельзя изменять свойсва во время работы");
            }
        }
        public ushort Port
        {
            get => port;
            set
            {
                if (!IsConnected)
                    port = value;
                throw new NotImplementedException("Нельзя изменять свойсва во время работы");
            }
        }

        public bool ProxyEnabled
        {
            get => proxyEnabled;
            set
            {
                if (!IsConnected)
                    proxyEnabled = value;
                throw new NotImplementedException("Нельзя изменять свойсва во время работы");
            }
        }
        public string ProxyHost
        {
            get => proxyHost;
            set
            {
                if (!IsConnected)
                    proxyHost = value;
                throw new NotImplementedException("Нельзя изменять свойсва во время работы");
            }
        }
        public ushort ProxyPort
        {
            get => proxyPort;
            set
            {
                if (!IsConnected)
                    proxyPort = value;
                throw new NotImplementedException("Нельзя изменять свойсва во время работы");
            }
        }
        public string ProxyLogin
        {
            get => proxyLogin;
            set
            {
                if (!IsConnected)
                    proxyLogin = value;
                throw new NotImplementedException("Нельзя изменять свойсва во время работы");
            }
        }
        public string ProxyPassword
        {
            get => proxyPassword;
            set
            {
                if (!IsConnected)
                    proxyPassword = value;
                throw new NotImplementedException("Нельзя изменять свойсва во время работы");
            }
        }










        #region Игровые свойства
        private ProtocolState subProtocol;
        public ProtocolState SubProtocol
        {
            get { return subProtocol; }
            private set
            {
                switch (value)
                {
                    case ProtocolState.HandShake:
                        RegisterHandShakePackets();
                        break;
                    case ProtocolState.Login:
                        RegisterLoginPackets();
                        break;
                    case ProtocolState.Game:
                        RegisterGamePackets();
                        break;
                }

                subProtocol = value;

            }
        }

        public Guid UUID
        {
            get => uUID;
            private set
            {
                uUID = value;
                OnPropertyChanged();
            }
        }

        public Point3 Location
        {
            get => location;
            private set
            {
                location = value;
                OnPropertyChanged();
            }
        }

        public Rotation Rotation
        {
            get => rotation; private set
            {
                rotation = value;
                OnPropertyChanged();
            }
        }

        public bool IsGround { get; private set; }


        #endregion

        #region События
        public event ConnectedHandler? Connected;
        public event ConnectionLostedHandler? ConnectionLosted;

        public event GameRejectedHandler? GameRejected;
        public event GameJoinedHandler? GameJoined;
        public event MessageReceivedHandler? MessageReceived;

        public event PacketReceivedHandler? PacketReceived;
        public event PropertyChangedEventHandler? PropertyChanged;



        #endregion



        private static readonly IPacketProvider packetProvider754 = new PacketProvider754();

        public PacketManager PacketManager { get; set; }

        private IPacketProducer PacketFactory => PacketManager;


        private readonly CancellationTokenSource Cancellation = new();

        private Task ReadTask;

        #region Общие методы        
        public async Task LoginAsync()
        {
            CheckProperties();

            PacketManager = new PacketManager();

            this.tcpClient = new TcpClient();
            await this.tcpClient.ConnectAsync(Host, Port, Cancellation.Token);
            this.NetMcStream = new NetworkMinecraftStream(tcpClient.GetStream());
            this.packetReaderWriter = new PacketReaderWriter(NetMcStream);

            SubProtocol = ProtocolState.HandShake;

            await SendPacketAsync(new HandShakePacket(HandShakeIntent.LOGIN, 754, Port, Host));

            SubProtocol = ProtocolState.Login;

            await SendPacketAsync(new LoginStartPacket(Nickname));

            bool login;
            do
            {
                IPacket packet = await ReadPacketLoginAsync();

                login = await HandleLoginPackets(packet);

            } while (!login);

            SubProtocol = ProtocolState.Game;
            Debug("Game");
            ReadTask = ReadLoop();

        }
        private bool Stoping = false;

        public async Task StopAsync()
        {
            Stoping = true;
            Cancellation.Cancel();
            tcpClient.Close();
            await ReadTask;
        }

        private async Task ReadLoop()
        {
            try
            {
                while (tcpClient.Connected)
                {
                    Cancellation.Token.ThrowIfCancellationRequested();
                    (int id, MinecraftStream stream) = await this.packetReaderWriter.ReadNextPacketAsync(Cancellation.Token);
                    Lazy<IPacket> packetLazy = null;
                    if (PacketFactory.TryGetInputPacket(id, out packetLazy))
                    {
                        packetLazy.Value.Read(stream);

                        await HandlePacket(packetLazy.Value);

                    }
                }
            }
            catch (IOException e)
            {
                if (!Stoping)
                    this.ConnectionLosted?.Invoke(this, e);
            }
            catch (Exception e)
            {
                if (!Stoping)
                    this.ConnectionLosted?.Invoke(this, e);
            }
            finally
            {
                tcpClient.Close();
            }
        }


        private async Task<IPacket> ReadPacketLoginAsync()
        {
            (int id, MinecraftStream stream) = await this.packetReaderWriter.ReadNextPacketAsync(Cancellation.Token);
            Lazy<IPacket> packet = null;
            PacketFactory.TryGetInputPacket(id, out packet);
            packet.Value.Read(stream);
            return packet.Value;

        }

        private async Task<bool> HandleLoginPackets(IPacket packet)
        {
            if (packet is LoginDisconnectPacket)
            {
                var disconnect = packet as LoginDisconnectPacket;
                Stoping = true;
                tcpClient.Close();
                Cancellation.Cancel();
                throw new LoginRejectException(disconnect.Message);
            }
            else if (packet is LoginSetCompressionPacket)
            {
                var compress = packet as LoginSetCompressionPacket;
                //Session.CompressionThreshold = compress.Threshold;

                this.packetReaderWriter.CompressionThreshold = compress.Threshold;
                return false;
            }
            else if (packet is EncryptionRequestPacket)
            {
                //TODO
                var request = packet as EncryptionRequestPacket;
                var RSAService = CryptoHandler.DecodeRSAPublicKey(request.PublicKey);
                byte[] secretKey = CryptoHandler.GenerateAESPrivateKey();

                await SendPacketAsync(new EncryptionResponsePacket(RSAService.Encrypt(secretKey, false), RSAService.Encrypt(request.VerifyToken, false)));

                NetMcStream.SwitchEncryption(secretKey);
                return false;
            }
            else if (packet is LoginSuccessPacket)
            {
                var succes = packet as LoginSuccessPacket;
                SubProtocol = ProtocolState.Game;
                UUID = succes.UUID;
                return true;
            }
            throw new NotImplementedException("Invalid Packet: " + packet.GetType().Name);
        }



        private async Task SendPacketAsync(IPacket packet)
        {
            try
            {
                int id = 0;
                if (PacketFactory.TryGetOutputId(packet.GetType(), out id))
                {
                    await this.packetReaderWriter.WritePacketAsync(packet, id, Cancellation.Token);
                }
            }
            catch (Exception e)
            {
                tcpClient.Close();

                this.ConnectionLosted?.Invoke(this, e);
            }
        }

        private void OnGameDisconnect(string message)
        {
            Stoping = true;
            Cancellation.Cancel();
            tcpClient.Close();
            this.GameRejected?.Invoke(this, message);


        }


        private void CheckProperties()
        {
            if (string.IsNullOrWhiteSpace(Nickname))
            {
                throw new InvalidOperationException("Введите ник");
            }
            if (string.IsNullOrWhiteSpace(Host))
            {
                throw new InvalidOperationException("Введите хост");
            }
            if (IsAuth)
            {
                if (string.IsNullOrWhiteSpace(Password))
                {
                    throw new InvalidOperationException("Введите пароль");
                }
            }


        }
        private bool EventsSub = false;
        private Guid uUID;
        private Point3 location;
        private Rotation rotation;
        private bool isAuth;
        private string nickname;
        private string password;
        private string host;
        private ushort port = 25565;
        private bool proxyEnabled;
        private string proxyHost;
        private ushort proxyPort;
        private string proxyLogin;
        private string proxyPassword;




        #endregion

        #region Работа с пакетами


        private async Task HandlePacket(IPacket packet)
        {
            Debug("Пришел пакет: " + packet.GetType().Name);

            this.PacketReceived?.Invoke(this, packet);
            //Console.WriteLine(packet.GetType().Name);


            if (packet is ServerJoinGamePacket)
            {
                var join = packet as ServerJoinGamePacket;
                this.GameJoined?.Invoke(this);
            }
            else if (packet is ServerDisconnectPacket)
            {
                var disconnect = packet as ServerDisconnectPacket;
                OnGameDisconnect(disconnect.Message);
            }
            else if (packet is ServerKeepAlivePacket)
            {
                var keepalive = packet as ServerKeepAlivePacket;
                await SendPacketAsync(new ClientKeepAlivePacket(keepalive.PingID));
            }
            else if (packet is ServerRespawnPacket)
            {
                var respawn = packet as ServerRespawnPacket;

            }
            else if (packet is ServerChatPacket)
            {
                var message = packet as ServerChatPacket;
                this.MessageReceived?.Invoke(this, message.Message);
            }
        }



        #endregion


        #region Методы действий
        public void SendLocation(Rotation rotation, bool isGround)
        {

        }

        public void SendLocation(Point3 position, Rotation rotation, bool isGround)
        {

        }
        public void LookHead(Rotation rotation)
        {

        }

        public void LookHead(Point3 targetpos)
        {

        }
        public void SendChat(string msg)
        {

        }

        public void SendLocation(bool isGround)
        {

        }

        public void SendLocation(Point3 position, bool isGround)
        {

        }

        public void SendLocation(Vector3 vector, bool isGround)
        {

        }

        public void SendLocation(Point3 position, float yaw, float pitch, bool isGround)
        {

        }

        public void SendLocation(Vector3 body, Vector3 head, bool isGround)
        {

        }
        #endregion






        private void RegisterHandShakePackets()
        {
            PacketManager.ClearAll();
            PacketManager.LoadOutputPackets(packetProvider754.ClientPackets.HandShakePackets);
        }
        private void RegisterLoginPackets()
        {
            PacketManager.ClearAll();

            PacketManager.LoadOutputPackets(packetProvider754.ClientPackets.LoginPackets);

            PacketManager.LoadInputPackets(packetProvider754.ServerPackets.LoginPackets);
        }
        private void RegisterGamePackets()
        {
            PacketManager.ClearAll();

            PacketManager.LoadOutputPackets(packetProvider754.ClientPackets.GamePackets);

            PacketManager.LoadInputPackets(packetProvider754.ServerPackets.GamePackets);
        }






        public void ClickBlock(Point3_Int pos)
        {

        }

        public void UseItem()
        {

        }

        public void UseItem(byte slot)
        {

        }

        public void UseBlock(Point3_Int pos)
        {

        }

        private void OnPropertyChanged([CallerMemberName] string name = "")
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            tcpClient?.Dispose();
        }
    }
}
