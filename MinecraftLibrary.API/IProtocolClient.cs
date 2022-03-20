using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.Geometry;
using System.ComponentModel;

namespace MinecraftLibrary.API
{
    /// <summary>
    /// Предоставляет свойства и методы для работы с протоколом
    /// </summary>
    public interface IProtocolClient : INotifyPropertyChanged, IDisposable
    {
        #region Свойства

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


        #endregion

        #region Методы
        void Connect();
        void Close();

        void SendChat(string msg);

        void SendLocation(bool isGround);
        void SendLocation(Point3 position, bool isGround);
        void SendLocation(Rotation rotation, bool isGround);
        void SendLocation(Point3 position, Rotation rotation, bool isGround);

        #endregion


        event EventHandler<ProtocolClientDisconnectEventArg> Disconnected;
        event EventHandler<ServerChatEventArgs> ChatMessageEvent;


        event Action LoginSucces;
        event Action Connected;
    }
}
