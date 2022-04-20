using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Types.Chat;
using MinecraftLibrary.Geometry;

namespace MinecraftLibrary.API
{
    public interface IMinecraftHandler
    {
        void OnDisconnect(Exception e);
        void OnDisconnect(string reason);

        void OnPacketReceived(IPacket packet);

        void OnLoginSucces(Guid uuid);
        void OnLoginReject(ChatMessage message);

        void OnGameJoined();

        void OnChat(string message);
        void OnPositionRotation(Point3 pos, Rotation rot, bool onGround);
    }
}
