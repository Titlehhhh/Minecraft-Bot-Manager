using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.Geometry;
using System.ComponentModel;

namespace MinecraftLibrary.API
{
    /// <summary>
    /// Предоставляет свойства и методы для работы с протоколом майнкрафт
    /// </summary>
    public interface IMinecraftClient : IDisposable
    {
       
        bool IsConnected { get; }


        string Nickname { get; set; }
        string Host { get; set; }
        ushort Port { get; set; }

        bool IsAuth { get; set; }

        TcpClientSession Session { get; }

        IPacketManager PacketManager { get; set; }

        ProtocolState SubProtocol { get; }

        Guid UUID { get; }

        Point3 Location { get; }
        Point3_Int ChunkLocation { get; }
        Point3_Int ChunkBlockLOcation { get; }

        Rotation Rotation { get; }

        bool IsGround { get; }


        void Connect();
        void Close();

        void SendChat(string msg);

        void SendLocation(bool isGround);
        void SendLocation(Point3 position, bool isGround);
        void SendLocation(Rotation rotation, bool isGround);
        void SendLocation(Point3 position, Rotation rotation, bool isGround);
        void ClickBlock(Point3_Int pos);
        void UseItem();
        void UseItem(byte slot);

        void UseBlock(Point3_Int pos);


        public event EventHandler<ProtocolClientDisconnectEventArg> Disconnected;
        public event EventHandler<ChatEventArgs> ChatMessageEvent;
        public event Action LoginSucces;
        public event Action Connected;
        public event Action JoiningGame;
        public event Action Respawning;
        public event Action UpdatePositionRotation;

    }
}
