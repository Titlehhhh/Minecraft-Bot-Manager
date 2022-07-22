using McProtoNet.Core;
using McProtoNet.Core.Packets;
using McProtoNet.Core.Protocol;
using McProtoNet.Protocol754;
using McProtoNet.Utils;
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
        private readonly string nick;
        private readonly TcpClient tcpClient;
        private readonly ILogger _logger;

        private MinecraftClient754(ILogger logger)
        {
            _logger = logger;
        }
        public MinecraftClient754(TcpClient tcpClient, string nick, ILogger logger) : this(logger)
        {
            this.nick = nick;
            client = new MinecraftProtocol(tcpClient);
            this.tcpClient = tcpClient;


            IsOnlineMode = false;
        }

        public MinecraftClient754(TcpClient tcpClient, string nick, string sessionId, ILogger logger) : this(tcpClient, nick, logger)
        {
            this.sessionId = sessionId;
            IsOnlineMode = true;
        }

        public int TargetProtocolVersion => 754;

        private IPacketProtocol client;

        public event GameKickedHandler GameKicked;
        public event LoginRejectedHandler LoginRejected;
        public event OnErrorHandler OnError;
        public event PacketReceivedHandler PacketReceived;
        public event PacketSentingHandler PacketSenting;
        public event PacketSentedHandler PacketSented;
        public event PropertyChangedEventHandler? PropertyChanged;

        public void Close()
        {

            //Dispose();
        }
        public void Dispose()
        {

        }

        public void QueuePacket(Packet packet)
        {
            if (packets.TryGetOutputId(packet.GetType(), out int id))
            {
                PacketSenting?.Invoke(packet);
                client.SendPacket(packet, id);                
                PacketSented?.Invoke(packet);
            }
        }
       
        private Packet ReadNextPacket()
        {
            (int id, MemoryStream data) = client.ReadNextPacket();

            if (packets.TryGetInputPacket(id, out Packet packet))
            {
                data.Dispose();
                PacketReceived?.Invoke(packet);
                return packet;
            }
            throw new InvalidOperationException("Unkown packet: " + id);
        }

        public void Login(string serverName, ushort port)
        {
            try
            {
                InternalLogin(serverName, port);
                StartGameMode();

            }
            catch (Exception e)
            {
                OnError?.Invoke(e);
            }
        }

        private void StartGameMode()
        {
            new Thread(() =>
            {
                while (tcpClient.Connected)
                {
                    Packet packet = ReadNextPacket();
                }
            })
            { IsBackground = true }
            .Start();
        }

        private void InternalLogin(string serverName, ushort port)
        {
            Mode = ProtocolMode.Handshake;
            _logger.Info("Рукопожатие");
            this.QueuePacket(new HandShakePacket(HandShakeIntent.LOGIN, TargetProtocolVersion, serverName, port));
            Mode = ProtocolMode.Login;
            this.QueuePacket(new LoginStartPacket(this.nick));
            bool need = true;

            while (need)
            {
                Packet loginPacket = this.ReadNextPacket();
                need = !HandleLoginPacket(loginPacket);
            }
        }

        private bool HandleLoginPacket(Packet packet)
        {
            if (packet is LoginSetCompressionPacket compressionPacket)
            {
                client.SwitchCompression(compressionPacket.Threshold);
            }
            else if (packet is EncryptionRequestPacket encryptionRequestPacket)
            {

               
                var RSAService = CryptoHandler.DecodeRSAPublicKey(encryptionRequestPacket.PublicKey);
                var privateKey = CryptoHandler.GenerateAESPrivateKey();

                if (IsOnlineMode)
                {
                    throw new Exception("Онлайн режим пока недоступен");
                }


                var key_enc = RSAService.Encrypt(privateKey, false);
                var token_enc = RSAService.Encrypt(encryptionRequestPacket.VerifyToken, false);
                var response = new EncryptionResponsePacket(key_enc, token_enc);
                QueuePacket(response);


                client.SwitchEncryption(privateKey);


            }
            else if (packet is LoginDisconnectPacket disconnectPacket)
            {
                tcpClient.Close();
                LoginRejected?.Invoke(disconnectPacket.Message);
            }
            else if(packet is LoginSuccessPacket successPacket)
            {
                return true;
            }
            return false;
        }
    }
}
