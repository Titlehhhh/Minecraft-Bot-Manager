using MinecraftLibrary.API;
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
    public class ProtocolClient : IProtocolClient
    {
        private ProtocolState subProtocol;

        public string Nickname { get; set; }
        public string Host { get; set; }
        public ushort Port { get; set; }
        public bool IsAuth { get; set; }

        #region Игровые свойства
        public Point3 Location
        {
            get => location;
            private set
            {
                location = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ChunkLocation));
                OnPropertyChanged(nameof(ChunkBlockLocation));
            }
        }

        public Point3_Int ChunkLocation => new Point3_Int(Location.ChunkX, Location.ChunkY, Location.ChunkZ);

        public Point3_Int ChunkBlockLocation => new Point3_Int(Location.ChunkBlockX, Location.ChunkBlockY, Location.ChunkBlockZ);

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
                OnPropertyChanged();
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

        public Rotation Rotation
        {
            get => rotation; private set
            {
                rotation = value;
                OnPropertyChanged();
            }
        }

        public bool IsGround
        {
            get => isGround; private set
            {
                isGround = value;
                OnPropertyChanged();
            }
        }
        #endregion
        #region Сервисы

        private static readonly IPacketProvider packetProvider754 = new PacketProvider754();

        public IPacketManager PacketManager { get; set; }

        public TcpClientSession Session { get; private set; }
        #endregion

        #region События
        public event EventHandler<ProtocolClientDisconnectEventArg> Disconnected;
        public event EventHandler<ServerChatEventArgs> ChatMessageEvent;
        public event Action LoginSucces;
        public event Action Connected;
        public event PropertyChangedEventHandler? PropertyChanged;
        #endregion

        #region Поля
        private Point3 location;
        private Point3_Int chunkLocation;
        private Guid uUID;
        private Rotation rotation;
        private bool isGround;
        #endregion

        #region Общие методы
        public void Disconnect()
        {

        }
        public void Connect()
        {
            Validate();

            Session = new TcpClientSession();
            if(PacketManager is null)
            {
                throw new NullReferenceException(nameof(PacketManager) + " был null");
            }
            Session.PacketFactory = this.PacketManager;

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
            Session.Connected -= Session_Connected;
            Session.Disconnected -= Session_Disconnected;
            Session.PacketReceived -= Session_PacketReceived;
            Session.PacketSent -= Session_PacketSent;
            Session.PacketSend -= Session_PacketSend;
        }
        private void RegisterEvents()
        {
            Session.Connected += Session_Connected;
            Session.Disconnected += Session_Disconnected;
            Session.PacketReceived += Session_PacketReceived;
            Session.PacketSent += Session_PacketSent;
            Session.PacketSend += Session_PacketSend;
        }
        #endregion

        #region Работа с пакетами
        private void Session_Connected()
        {
            Console.WriteLine("Connected");
            SendPacket(new HandShakePacket(HandShakeIntent.LOGIN, 754, Port, Host));
        }

        private void Session_PacketSent(object? sender, PacketSentEventArgs e)
        {
            Console.WriteLine("PacketSent: " + e.Packet.GetType().Name);
            if (e.Packet is HandShakePacket)
            {
                this.SubProtocol = ProtocolState.Login;
                SendPacket(new LoginStartPacket(Nickname));
            }
        }

        private void Session_PacketSend(object? sender, PacketSendEventArgs e)
        {
            Console.WriteLine("PacketSend: " + e.Packet.GetType().Name);
        }

        private void Session_PacketReceived(object? sender, PacketReceivedEventArgs e)
        {
            Console.WriteLine(e.Packet.GetType().Name);
            if (e.Packet is LoginDisconnectPacket)
            {
                Session.Disconnect();
                Console.WriteLine("Disconnect: " + (e.Packet as LoginDisconnectPacket).Message);
            }
            else if (e.Packet is LoginSetCompressionPacket)
            {
                var compress = e.Packet as LoginSetCompressionPacket;
                Session.CompressionThreshold = compress.Threshold;

            }
            else if (e.Packet is EncryptionRequestPacket)
            {

            }
            else if (e.Packet is LoginSuccessPacket)
            {
                SubProtocol = ProtocolState.Game;
            }
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
            UnRegisterEvents();
        }
        
        private void OnPropertyChanged([CallerMemberName] string name = "")
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public void Dispose()
        {
            Close();

        }
    }
}
