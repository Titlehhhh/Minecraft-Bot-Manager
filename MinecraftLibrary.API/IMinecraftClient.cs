using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Types.Chat;
using MinecraftLibrary.Geometry;
using System.ComponentModel;

namespace MinecraftLibrary.API
{
    public interface IMinecraftClient : IDisposable, INotifyPropertyChanged
    {
        Guid UUID { get; }


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

        event Action LoginSucccesed;
        event Action GameKicked;
        event Action LoginKicked;


        
    }

    public interface IPacketObserver
    {
        void OnConnected();
        void OnGameKick(string message);
        void OnLoginKick(string message);

        void OnLoginSucces(string nick, Guid uuid);
        void OnGameJoined(int entityId);
        void OnRespawn(int entityid);

        void OnPositionRotation(Point3 pos, Rotation rot, bool onGround, IReadOnlyCollection<PositionElement> relatives);
        void OnChatMessage(ChatMessage message);

        void OnKeepAlive(int id);
    }

}
