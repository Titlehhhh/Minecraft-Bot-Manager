using MinecraftLibrary.API;
using MinecraftLibrary.API.Inventory;
using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.Client.Networking;
using MinecraftLibrary.Core.Protocol;
using MinecraftLibrary.Geometry;
using ProtocolLib740;
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



        public IContainer CurrentContainer { get; private set; }

        public Point3 Location { get; private set; }

        public Point3_Int ChunkLocation { get; private set; }

        public Point3_Int CnunkBlockLocation { get; private set; }

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

        public event EventHandler<ProtocolClientDisconnectEventArg> Disconnected;


        private readonly IPacketManager PacketManager = new DefaultPacketManager();

        private IPacketProvider PacketProvider;

        public void Connect()
        {
            PacketProvider = new PacketProvider740();

            Session = new TcpClientSession();
            Session.Host = this.Host;
            Session.Port = this.Port;
            Session.Packets = PacketManager;
            RegisterEvents();
            SubProtocol = ProtocolState.HandShake;
            Session.Connect();

        }

        
        private void UnRegisterEvents()
        {
            Session.Connected -= Session_Connected;
            Session.Disconnected -= Session_Disconnected;
            Session.PacketReceived -= Session_PacketReceived;
            Session.PacketSend -= Session_PacketSend;
            Session.PacketSent -= Session_PacketSent;
        }
        private void Session_Connected(ITcpClientSession obj)
        {
            SendPacket(new HandShakePacket(HandShakeIntent.LOGIN, 740, Port, Host));
        }

        private void Session_PacketSent(object? sender, PacketSentEventArgs e)
        {
            if(e.Packet is HandShakePacket)
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
            Console.WriteLine(e.Packet.GetType().Name);
        }

        private void Session_Disconnected(object? sender, DisconnectedEventArgs e)
        {
            UnRegisterEvents();
            Disconnected?.Invoke(this, new ProtocolClientDisconnectEventArg(e.Message, e.Exception));
        }

        private void SendPacket(IPacket packet)
        {
            Session.SendPacket(packet);
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

        private void RegisterHandShakePackets()
        {
            PacketManager.ClearAll();
            PacketManager.LoadInputPackets(PacketProvider.ClientPackets.HandShakePackets);
        }
        private void RegisterLoginPackets()
        {
            PacketManager.ClearAll();

            PacketManager.LoadInputPackets(PacketProvider.ClientPackets.LoginPackets);

            PacketManager.LoadOutputPackets(PacketProvider.ServerPackets.LoginPackets);
        }
        private void RegisterGamePackets()
        {
            PacketManager.ClearAll();

            PacketManager.LoadInputPackets(PacketProvider.ClientPackets.GamePackets);

            PacketManager.LoadOutputPackets(PacketProvider.ServerPackets.GamePackets);
        }
        private void RegisterEvents()
        {
            Session.Connected += Session_Connected;
            Session.Disconnected += Session_Disconnected;
            Session.PacketReceived += Session_PacketReceived;
            Session.PacketSend += Session_PacketSend;
            Session.PacketSent += Session_PacketSent;
        }
    }
}
