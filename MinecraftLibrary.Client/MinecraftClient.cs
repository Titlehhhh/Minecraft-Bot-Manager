using MinecraftLibrary.API;
using MinecraftLibrary.API.Inventory;
using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.Client.Networking;
using MinecraftLibrary.Core.Protocol;
using MinecraftLibrary.Geometry;
using ProtocolLib740.Packets.Client;
using ProtocolLib740.Packets.Server;

namespace MinecraftLibrary.Client
{
    public class MinecraftClient : IMinecraftClient
    {
        private ProtocolState subProtocol;

        public string Nickname { get; set; }
        public string Host { get; set; }
        public ushort Port { get; set; }
        public ITcpClientSession Session { get; private set; }



        private Dictionary<Type, int> ClientPackets = new Dictionary<Type, int>();

        public IContainer CurrentContainer { get; private set; }

        public Point3 Location { get; private set; }

        public Point3_Int ChunkLocation { get; private set; }

        public Point3_Int CnunkBlockLocation { get; private set; }

        public ProtocolState SubProtocol
        {
            get { return subProtocol; }
            private set
            {

                subProtocol = value;
            }
        }

        public event EventHandler<ProtocolClientDisconnectEventArg> Disconnected;


        private readonly IPacketManager packetManager = new DefaultPacketManager();

        public void Connect()
        {
            Session = new TcpClientSession();
            Session.Host = this.Host;
            Session.Port = this.Port;
            Session.Packets = packetManager;
            RegisterEvents();
            SubProtocol = ProtocolState.HandShake;
            Session.Connect();

        }

        private void RegisterHandShakePackets()
        {
            packetManager.ClearAll();
            packetManager.RegisterOutputPacket<HandShakePacket>(0x00);

        }
        private void RegisterLoginPackets()
        {
            packetManager.ClearAll();

            packetManager.RegisterOutputPacket(typeof(LoginStartPacket), 0x00);
            packetManager.RegisterOutputPacket(typeof(EncryptionResponsePacket), 0x01);
            packetManager.RegisterOutputPacket(typeof(LoginPluginResponsePacket), 0x02);



            packetManager.RegisterInputPacket<LoginDisconnectPacket>(0x00);
            packetManager.RegisterInputPacket<EncryptionRequestPacket>(0x01);
            packetManager.RegisterInputPacket<LoginSuccessPacket>(0x02);
            packetManager.RegisterInputPacket<LoginSetCompressionPacket>(0x03);
            packetManager.RegisterInputPacket<LoginPluginRequestPacket>(0x04);

        }

        private void RegisterGamePackets()
        {
            packetManager.ClearAll();

            packetManager.RegisterOutputPacket<ClientKeepAlivePacket>(0x10);
            packetManager.RegisterOutputPacket<ClientTeleportConfirmPacket>(0x00);
            packetManager.RegisterOutputPacket<ClientChatPacket>(0x03);

            packetManager.RegisterInputPacket<ServerKeepAlivePacket>(0x1F);
            packetManager.RegisterInputPacket<ServerChatPacket>(0x0E);
        }


        private void RegisterEvents()
        {
            Session.Connected += Session_Connected;
            Session.Disconnected += Session_Disconnected;
            Session.PacketReceived += Session_PacketReceived;
            Session.PacketSend += Session_PacketSend;
            Session.PacketSent += Session_PacketSent;
        }
        private void UnRegisterEvents()
        {
            Session.Connected -= Session_Connected;
            Session.Disconnected -= Session_Disconnected;
            Session.PacketReceived -= Session_PacketReceived;
            Session.PacketSend -= Session_PacketSend;
            Session.PacketSent -= Session_PacketSent;
        }

        private void Session_PacketSent(object? sender, PacketSentEventArgs e)
        {

        }

        private void Session_PacketSend(object? sender, PacketSendEventArgs e)
        {

        }

        private void Session_PacketReceived(object? sender, PacketReceivedEventArgs e)
        {

        }

        private void Session_Disconnected(object? sender, DisconnectedEventArgs e)
        {
            UnRegisterEvents();
            Disconnected?.Invoke(this, new ProtocolClientDisconnectEventArg(e.Message, e.Exception));
        }

        private void Session_Connected(ITcpClientSession obj)
        {

        }

        public void Disconnect()
        {

        }

        public void LookHead(float yaw, float pitch)
        {

        }

        public void LookHead(Point3 targetBlock)
        {

        }

        public void LookHead(Vector3 vector)
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
    }
}
