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
using System.Net.Sockets;
using System.Runtime.CompilerServices;

namespace MinecraftLibrary
{


    public class MinecraftClient754 : IDisposable, INotifyPropertyChanged
    {
        private readonly TcpClient tcpClient;
        private readonly NetworkMinecraftStream NetMcStream;
        private readonly PacketReaderWriter packetReaderWriter;
        public MinecraftClient754(TcpClient tcpClient)
        {
            this.tcpClient = tcpClient;
            this.NetMcStream = new NetworkMinecraftStream(tcpClient.GetStream());
            this.packetReaderWriter = new PacketReaderWriter(NetMcStream);
        }


        public bool IsConnected => tcpClient != null && tcpClient.Connected;

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


        #region Общие методы        
        public async Task LoginAsync()
        {
            SubProtocol = ProtocolState.HandShake;

            await SendPacketAsync(new HandShakePacket(HandShakeIntent.LOGIN, 754, Port, Host));

            SubProtocol = ProtocolState.Login;

            await SendPacketAsync(new LoginStartPacket(Nickname));



        }
        public async Task StopAsync()
        {


        }

        private async Task<IPacket> ReadPacketAsync()
        {

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
                OnDisconnect(e);
            }
        }

        private void OnDisconnect(DisconnectType type, string message)
        {

        }
        private void OnDisconnect(Exception e)
        {

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




        #endregion

        #region Работа с пакетами


        private async void HandlePacket(IPacket packet)
        {
            this.PacketReceived?.Invoke(this, packet);
            //Console.WriteLine(packet.GetType().Name);

            if (packet is LoginDisconnectPacket)
            {
                var disconnect = packet as LoginDisconnectPacket;

                StopAsync();

            }
            else if (packet is LoginSetCompressionPacket)
            {
                var compress = packet as LoginSetCompressionPacket;
                //Session.CompressionThreshold = compress.Threshold;

            }
            else if (packet is EncryptionRequestPacket)
            {
                //TODO
                var request = packet as EncryptionRequestPacket;
                var RSAService = CryptoHandler.DecodeRSAPublicKey(request.PublicKey);
                byte[] secretKey = CryptoHandler.GenerateAESPrivateKey();

                await SendPacket(new EncryptionResponsePacket(RSAService.Encrypt(secretKey, false), RSAService.Encrypt(request.VerifyToken, false)));

                //Session.SwitchEncryption(secretKey);
            }
            else if (packet is LoginSuccessPacket)
            {
                var succes = packet as LoginSuccessPacket;
                SubProtocol = ProtocolState.Game;
                UUID = succes.UUID;
                this.LoginSuccesed?.Invoke(this, UUID);
            }
            else if (packet is ServerJoinGamePacket)
            {
                var join = packet as ServerJoinGamePacket;
                this.GameJoined?.Invoke(this);
            }
            else if (packet is ServerDisconnectPacket)
            {
                var disconnect = packet as ServerDisconnectPacket;
                StopAsync();
                this.GameRejected?.Invoke(this, disconnect.Message);
            }
            else if (packet is ServerKeepAlivePacket)
            {
                var keepalive = packet as ServerKeepAlivePacket;
                await SendPacket(new ClientKeepAlivePacket(keepalive.PingID));
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

        private void Session_Disconnected(object? sender, Exception e)
        {
            //UnRegisterEvents();
            StopAsync();
            ConnectionLosted?.Invoke(this, e);
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
