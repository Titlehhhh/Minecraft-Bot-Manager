using MinecraftLibrary.API;
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
    public class MinecraftClient 
    {
        public bool IsConnected => Session != null && Session.IsConnected;

        

        



        private ProtocolState subProtocol;

        public bool IsAuth { get; set; }
        public string Nickname { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
        public ushort Port { get; set; }
        

        public bool ProxyEnabled { get; set; }
        public string ProxyHost { get; set; }
        public ushort ProxyPort { get; set; }
        public string ProxyLogin { get; set; }
        public string ProxyPassword { get; set; }


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



        private static readonly IPacketProvider packetProvider754 = new PacketProvider754();

        public PacketManager PacketManager { get; set; }

        public TcpClientSession Session { get; private set; }


       
       


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



            Session.PacketFactory = new PacketManager();
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
            //UnRegisterEvents();
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
            //this.Disconnected?.Invoke(this, new DisconnectedEventArgs(
            //    message,
            //    disconnectReason,
            //    exception
            //    ));
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
               // UnRegisterEvents();
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
