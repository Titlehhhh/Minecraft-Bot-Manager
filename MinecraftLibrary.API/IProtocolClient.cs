using MinecraftLibrary.API.Inventory;
using MinecraftLibrary.API.Networking;
using MinecraftLibrary.Geometry;
using System.ComponentModel;
using MinecraftLibrary.API.Protocol;

namespace MinecraftLibrary.API
{
    /// <summary>
    /// Предоставляет свойства и методы для работы с протоколом
    /// </summary>
    public interface IProtocolClient : INotifyPropertyChanged, IDisposable
    {
        #region Свойства

        ITcpClientSession Session { get; }

        ProtocolState SubProtocol { get; }

        Guid UUID { get; }

        Point3 Location { get; }

        Point3_Int ChunkLocation { get; }

        Point3_Int CnunkBlockLocation { get; }

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
