using MinecraftLibrary.API;
using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Proxy;
using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.Geometry;
using MinecraftLibrary.Protocol;
using ProtocolLib754;
using ProtocolLib754.Packets.Client;
using ProtocolLib754.Packets.Server;
using System.ComponentModel;
using System.Net;
using System.Runtime.CompilerServices;

namespace MinecraftLibrary
{
    

    public class MinecraftClient : IDisposable
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

        public Guid UUID { get; private set; }

        public Point3 Location { get; private set; }

        public Rotation Rotation { get; private set; }

        public bool IsGround { get; private set; }


        #endregion

        #region События
        public event ConnectedHandler? Connected;
        public event ConnectionLostedHandler? ConnectionLosted;
        public event LoginRejectedHandler? LoginRejected;
        public event LoginSucessedHandler? LoginSuccesed;
        public event GameRejectedHandler? GameRejected;

        public event MessageReceivedHandler? MessageReceived;

        public event PacketReceivedHandler? PacketReceived;


        
        #endregion



        private static readonly IPacketProvider packetProvider754 = new PacketProvider754();

        public PacketManager PacketManager { get; set; }

        public TcpClientSession Session { get; private set; }




        #region Общие методы        
        public void Start()
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



            Session.PacketFactory = new PacketManager();
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
            SendPacket(new HandShakePacket(HandShakeIntent.LOGIN, 754, Port, Host));
        }

        private void Session_PacketSent(object? sender, PacketSentEventArgs e)
        {
            if (e.Packet is HandShakePacket)
            {
                this.SubProtocol = ProtocolState.Login;
                SendPacket(new LoginStartPacket(Nickname));
            }
        }

        private void Session_PacketSend(object? sender, PacketSendEventArgs e)
        {

        }

        private void Session_PacketReceived(object? sender, PacketReceivedEventArgs e)
        {
            if (e.Packet is LoginDisconnectPacket)
            {
                var disconnect = e.Packet as LoginDisconnectPacket;

                Close();

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
            }
            else if (e.Packet is LoginSuccessPacket)
            {
                var succes = e.Packet as LoginSuccessPacket;
                SubProtocol = ProtocolState.Game;
                UUID = Guid.Parse(succes.UUID);
                this.LoginSuccesed?.Invoke(this, UUID);
            }
            else if (e.Packet is ServerJoinGamePacket)
            {
                var join = e.Packet as ServerJoinGamePacket;

            }
            else if (e.Packet is ServerDisconnectPacket)
            {
                var disconnect = e.Packet as ServerDisconnectPacket;
                Close();
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
        }

        private void Session_Disconnected(object? sender, Exception e)
        {
            //UnRegisterEvents();
            Close();
            ConnectionLosted?.Invoke(this, e);
        }

        private void SendPacket(IPacket packet)
        {
            if (this.IsConnected)
            {
                Session.SendPacket(packet);
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



        public void Close()
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
