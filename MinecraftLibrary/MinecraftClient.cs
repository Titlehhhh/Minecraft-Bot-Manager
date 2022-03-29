using MinecraftLibrary.API;
using MinecraftLibrary.API.Crypto;
using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.Geometry;
using MinecraftLibrary.Protocol;
using ProtocolLib754;
using ProtocolLib754.Packets.Client;
using ProtocolLib754.Packets.Server;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MinecraftLibrary
{


    public class MinecraftClient : IDisposable, INotifyPropertyChanged
    {
        public bool IsConnected => Session != null && Session.IsConnected;

        public bool IsAuth { get; init; }
        public string Nickname { get; init; }
        public string Password { get; init; }
        public string Host { get; init; }
        public ushort Port { get; init; } = 25565;


        public bool ProxyEnabled { get; init; }
        public string ProxyHost { get; init; }
        public ushort ProxyPort { get; init; }
        public string ProxyLogin { get; init; }
        public string ProxyPassword { get; init; }










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
        public event LoginRejectedHandler? LoginRejected;
        public event LoginSucessedHandler? LoginSuccesed;
        public event GameRejectedHandler? GameRejected;
        public event GameJoinedHandler? GameJoined;
        public event MessageReceivedHandler? MessageReceived;

        public event PacketReceivedHandler? PacketReceived;
        public event PropertyChangedEventHandler? PropertyChanged;



        #endregion



        private static readonly IPacketProvider packetProvider754 = new PacketProvider754();

        public PacketManager PacketManager { get; set; }

        public TcpClientSession Session { get; private set; }




        #region Общие методы        
        public async Task StartAsync()
        {

            if (this.IsConnected)
            {
                throw new InvalidOperationException("Клиент подключен");
            }
            CheckProperties();

            Session = new TcpClientSession()
            {
                Host = this.Host,
                Port = this.Port,
            };
            if (this.ProxyEnabled)
            {
                //TODO
            }

            SubscribeEvents();


            this.PacketManager = new PacketManager();

            SubProtocol = ProtocolState.HandShake;
            Session.PacketFactory = this.PacketManager;

            await Session.Connect();
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

        private void SubscribeEvents()
        {
            if (!EventsSub)
            {

                Session.Connected += Session_Connected;
                Session.Disconnected += Session_Disconnected;
                Session.PacketReceived += Session_PacketReceived;
                Session.PacketSend += Session_PacketSend;
                Session.PacketSent += Session_PacketSent;
                EventsSub = true;
            }
        }
        private void UnSubscribeEvents()
        {
            if (EventsSub)
            {
                Session.Connected -= Session_Connected;
                Session.Disconnected -= Session_Disconnected;
                Session.PacketReceived -= Session_PacketReceived;
                Session.PacketSend -= Session_PacketSend;
                Session.PacketSent -= Session_PacketSent;
                EventsSub = false;
            }
        }


        #endregion

        #region Работа с пакетами
        private void Session_Connected()
        {
            Console.WriteLine("gg");
            this.Connected?.Invoke(this);
            SendPacket(new HandShakePacket(HandShakeIntent.LOGIN, 754, Port, Host));
            this.SubProtocol = ProtocolState.Login;
            SendPacket(new LoginStartPacket(Nickname));
        }

        private void Session_PacketSent(object? sender, PacketSentEventArgs e)
        {
            Console.WriteLine("SentPAcket: " + e.Packet.GetType().Name);

        }

        private void Session_PacketSend(object? sender, PacketSendEventArgs e)
        {
            Console.WriteLine("SendPAcket: " + e.Packet.GetType().Name);
        }

        private void Session_PacketReceived(object? sender, PacketReceivedEventArgs e)
        {
            this.PacketReceived?.Invoke(this, e.Packet);
            //Console.WriteLine(e.Packet.GetType().Name);

            if (e.Packet is LoginDisconnectPacket)
            {
                var disconnect = e.Packet as LoginDisconnectPacket;

                Disconnect();

                this.LoginRejected?.Invoke(this, disconnect.Message);

            }
            else if (e.Packet is LoginSetCompressionPacket)
            {
                var compress = e.Packet as LoginSetCompressionPacket;
                Session.CompressionThreshold = compress.Threshold;

            }
            else if (e.Packet is EncryptionRequestPacket)
            {
                //TODO
                var request = e.Packet as EncryptionRequestPacket;
                var RSAService = CryptoHandler.DecodeRSAPublicKey(request.PublicKey);
                byte[] secretKey = CryptoHandler.GenerateAESPrivateKey();

                SendPacket(new EncryptionResponsePacket(RSAService.Encrypt(secretKey, false), RSAService.Encrypt(request.VerifyToken, false)));

                Session.SwitchEncryption(secretKey);
            }
            else if (e.Packet is LoginSuccessPacket)
            {
                var succes = e.Packet as LoginSuccessPacket;
                SubProtocol = ProtocolState.Game;
                UUID = succes.UUID;
                this.LoginSuccesed?.Invoke(this, UUID);
            }
            else if (e.Packet is ServerJoinGamePacket)
            {
                var join = e.Packet as ServerJoinGamePacket;
                this.GameJoined?.Invoke(this);
            }
            else if (e.Packet is ServerDisconnectPacket)
            {
                var disconnect = e.Packet as ServerDisconnectPacket;
                Disconnect();
                this.GameRejected?.Invoke(this, disconnect.Message);
            }
            else if (e.Packet is ServerKeepAlivePacket)
            {
                var keepalive = e.Packet as ServerKeepAlivePacket;
                SendPacket(new ClientKeepAlivePacket(keepalive.PingID));
            }
            else if (e.Packet is ServerRespawnPacket)
            {
                var respawn = e.Packet as ServerRespawnPacket;

            }
            else if (e.Packet is ServerChatPacket)
            {
                var message = e.Packet as ServerChatPacket;
                this.MessageReceived?.Invoke(this, message.Message);
            }
        }

        private void Session_Disconnected(object? sender, Exception e)
        {
            //UnRegisterEvents();
            Disconnect();
            ConnectionLosted?.Invoke(this, e);
        }

        private void SendPacket(IPacket packet)
        {
            try
            {
                if (this.IsConnected)
                {
                    Session.SendPacket(packet);
                }
            }
            catch (Exception e)
            {
                Disconnect();
                ConnectionLosted?.Invoke(this, e);
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



        public void Disconnect()
        {
            if (Session != null)
            {
                Session.Disconnect();
                UnSubscribeEvents();
            }
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
            if (Session != null)
            {
                UnSubscribeEvents();
                Session.Dispose();
                Session = null;
            }

            GC.SuppressFinalize(this);
        }
    }
}
