using MinecraftLibrary.API;
using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.Geometry;
using ProtocolLib754;
using ProtocolLib754.Packets.Client;
using ProtocolLib754.Packets.Server;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MinecraftLibrary
{
    public class MinecraftClient : IMinecraftClient
    {
        public bool IsConnected => Session != null && Session.IsConnected;

        public MinecraftClient()
        {

        }



        private ProtocolState subProtocol;
        private bool eventsRegister;

        public string Nickname { get; set; }
        public string Host { get; set; }
        public ushort Port { get; set; }
        public bool IsAuth { get; set; }

        #region Игровые свойства

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
        #region Сервисы

        private static readonly IPacketProvider packetProvider754 = new PacketProvider754();

        public IPacketManager PacketManager { get; set; }

        public TcpClientSession Session { get; private set; }


        #endregion

        #region События

        #endregion
        private readonly object eventsLock = new object();

        public event EventHandler<ChatEventArgs> ChatMessageEvent;
        public event EventHandler<LoginSuccesEventArgs> LoginSuccesed;
        public event Action Connected;
        public event Action JoiningGame;
        public event Action Respawning;
        public event Action UpdatePositionRotation;
        public event EventHandler<DisconnectedEventArgs> Disconnected;

        private bool EventsRegister
        {
            get => eventsRegister;
            set
            {
                lock (eventsLock)
                { eventsRegister = value; }
            }
        }

        public Point3_Int ChunkLocation => throw new NotImplementedException();

        public Point3_Int ChunkBlockLocation => throw new NotImplementedException();

        #region Общие методы        
        public void Connect()
        {
            if (this.IsConnected)
            {
                throw new InvalidOperationException("Клинт подключен");
            }
            Session = new TcpClientSession();
            Validate();

            Session = new TcpClientSession();
            if (PacketManager is null)
            {
                throw new NullReferenceException(nameof(PacketManager) + " был null");
            }
            Session.PacketFactory = this.PacketManager;

            RegisterEvents();

        }
        private void Validate()
        {
            if (string.IsNullOrWhiteSpace(Nickname))
            {
                throw new InvalidOperationException("Введите ник");
            }
            if (string.IsNullOrWhiteSpace(Host))
            {
                throw new InvalidOperationException("Введите хость");
            }
        }

        private void UnRegisterEvents()
        {
            if (EventsRegister)
            {
                EventsRegister = false;
                Session.Connected -= Session_Connected;
                Session.Disconnected -= Session_Disconnected;
                Session.PacketReceived -= Session_PacketReceived;
                Session.PacketSent -= Session_PacketSent;
                Session.PacketSend -= Session_PacketSend;
            }
        }
        private void RegisterEvents()
        {
            if (!EventsRegister)
            {
                EventsRegister = true;
                Session.Connected += Session_Connected;
                Session.Disconnected += Session_Disconnected;
                Session.PacketReceived += Session_PacketReceived;
                Session.PacketSent += Session_PacketSent;
                Session.PacketSend += Session_PacketSend;
            }
        }
        #endregion

        #region Работа с пакетами
        private void Session_Connected()
        {

            this.Connected?.Invoke();
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
                OnDisconnect(disconnect.Message, DisconnectReason.LoginRejected);

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

            }
            else if (e.Packet is ServerJoinGamePacket)
            {
                var join = e.Packet as ServerJoinGamePacket;

            }
            else if (e.Packet is ServerDisconnectPacket)
            {
                var disconnect = e.Packet as ServerDisconnectPacket;
                OnDisconnect(disconnect.Message, DisconnectReason.InGameKick);
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
            UnRegisterEvents();
            OnDisconnect(e.Message, DisconnectReason.ConnectionLost, e);
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





        private void OnDisconnect(string message, DisconnectReason disconnectReason, Exception exception = null)
        {
            Close();
            this.Disconnected?.Invoke(this, new DisconnectedEventArgs(
                message,
                disconnectReason,
                exception
                ));
        }

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
                UnRegisterEvents();
                Dispose();
            }
        }
        public void Dispose()
        {
            Session?.Dispose();
            Session = null;

            GC.SuppressFinalize(this);
        }

        public void ClickBlock(Point3_Int pos)
        {
            throw new NotImplementedException();
        }

        public void UseItem()
        {
            throw new NotImplementedException();
        }

        public void UseItem(byte slot)
        {
            throw new NotImplementedException();
        }

        public void UseBlock(Point3_Int pos)
        {
            throw new NotImplementedException();
        }
    }
}
