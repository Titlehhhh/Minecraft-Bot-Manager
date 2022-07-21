using McProtoNet.Core;
using McProtoNet.Core.Packets;
using McProtoNet.Core.Protocol;
using McProtoNet.Protocol754;

using System.ComponentModel;
using System.Net.Sockets;

namespace MinecraftBotManager.Core.Minecraft.Clients
{
    public enum ProtocolMode
    {
        Handshake,
        Login,
        Game
    }

    public class MinecraftClient754 : IMinecraftClient, IDisposable
    {
        private static readonly IPacketCollection p754 = new PacketCollection754();

        private IPacketRepository packetRepository = new PacketRepository(p754.GetAllPackets(PacketSide.Client));

        private IPacketProvider packets;

        private ProtocolMode mode;
        public ProtocolMode Mode
        {
            get => mode;
            private set
            {
                switch (value)
                {
                    case ProtocolMode.Handshake:
                        packets = packetRepository.GetPackets(PacketCategory.HandShake);
                        break;
                    case ProtocolMode.Login:
                        packets = packetRepository.GetPackets(PacketCategory.Login);
                        break;
                    case ProtocolMode.Game:
                        packets = packetRepository.GetPackets(PacketCategory.Game);
                        break;
                }

                mode = value;
            }
        }


        public bool IsOnlineMode { get; private set; }

        private readonly string sessionId;


        public MinecraftClient754(TcpClient tcpClient, string nick)
        {

            client = new MinecraftProtocol(tcpClient);
            IsOnlineMode = false;
        }

        public MinecraftClient754(TcpClient tcpClient, string nick, string sessionId) : this(tcpClient, nick)
        {
            this.sessionId = sessionId;
            IsOnlineMode = true;
        }

        public int TargetProtocolVersion => 754;

        private IPacketProtocol client;

        public event PropertyChangedEventHandler? PropertyChanged;
        public event PacketReceivedHandler PacketReceived;
        public event ErrorHandler OnError;
        public event DisconnectedHandler Disconnected;
        public event PacketSendHandler PacketSend;
        public event PacketSentHandler PacketSent;

        public void Close()
        {

            //Dispose();
        }
        public void Dispose()
        {

        }

        public void QueuePacket(Packet packet)
        {

        }
        public void Start(string serverName, ushort port)
        {
            Mode = ProtocolMode.Handshake;

            client.SendPacket(new HandShakePacket(HandShakeIntent.LOGIN, TargetProtocolVersion, serverName, port), 0);
            Mode = ProtocolMode.Login;


        }
    }
}
