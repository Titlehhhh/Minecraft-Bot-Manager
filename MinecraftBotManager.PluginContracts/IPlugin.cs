using MinecraftLibrary;
using MinecraftLibrary.API.Types.Chat;
using MinecraftLibrary.Geometry;
using System.ComponentModel.Composition;


namespace MinecraftBotManager.PluginContracts
{

    public interface IPlugin
    {
        [Import]
        public MinecraftClient Client { get; set; }

        void Inizialize();
        void UnLoaded();

        void OnLoginSucces(Guid uuid);
        void OnConnected();

        void OnDisconnect();
        void OnDisconnect(Exception e);


        void OnPositionRotation(Point3 pos, Rotation rot, bool onGround);

        void OnLoginReject(ChatMessage reason);
        void OnChat(ChatMessage message);
        void OnGameKick(ChatMessage reason);
        void OnGameJoined();

    }
}