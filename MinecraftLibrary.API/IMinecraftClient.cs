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
        Point3_Int ChunkBlockLocation { get; }

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


        event EventHandler<DisconnectedEventArgs> Disconnected;
        event EventHandler<ChatEventArgs> ChatMessageEvent;
        event EventHandler<LoginSuccesEventArgs> LoginSuccesed;

        event Action Connected;
        event Action JoiningGame;
        event Action Respawning;
        event Action UpdatePositionRotation;

    }
}
