using MinecraftLibrary.API;
using MinecraftLibrary.API.Inventory;
using MinecraftLibrary.API.Networking;
using MinecraftLibrary.Client.Networking;
using MinecraftLibrary.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtocolLib740.Packets.Server;
using ProtocolLib740.Packets.Client;
using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.Core.Protocol;

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

        public void Connect()
        {
            Session = new TcpClientSession();
            Session.Host = this.Host;
            Session.Port = this.Port;

            RegisterEvents();
            SubProtocol = ProtocolState.HandShake;
            Session.Connect();

        }

        private void RegisterHandShakePackets()
        {
            ClientPackets.Clear();
            ClientPackets.Add(typeof(HandShakePacket), 0x00);
        }
        private void RegisterLoginPackets()
        {
            ClientPackets.Clear();
            ClientPackets.Add(typeof(LoginStartPacket),0x00);
            ClientPackets.Add(typeof(EncryptionResponsePacket), 0x01);
            ClientPackets.Add(typeof(LoginPluginResponsePacket), 0x02);

            IPacketRepository LoginPackets = new DefaultPacketRepository();

            LoginPackets.RegisterPacket<LoginDisconnectPacket>(0x00);
            LoginPackets.RegisterPacket<EncryptionRequestPacket>(0x01);
            LoginPackets.RegisterPacket<LoginSuccessPacket>(0x02);
            LoginPackets.RegisterPacket<LoginSetCompressionPacket>(0x03);
            LoginPackets.RegisterPacket<LoginPluginRequestPacket>(0x04);

            Session.InputPackets = LoginPackets;
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
