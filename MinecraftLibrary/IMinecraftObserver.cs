using MinecraftLibrary.API.Types.Chat;
using MinecraftLibrary.Geometry;

namespace MinecraftLibrary
{
    public interface IMinecraftObserver
    {
        void OnConnect();
        void OnDisconnect();
        void OnDisconnect(Exception e);

        void OnLoginSucces(Guid uuid);
        void OnLoginReject(ChatMessage message);
        void OnGameKick(ChatMessage reason);

        void OnChat(ChatMessage message);
        void OnPositionRotation(Point3 pos, Rotation rot, bool onGround);
    }
}
