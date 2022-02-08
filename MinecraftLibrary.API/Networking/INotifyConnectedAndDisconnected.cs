using MinecraftLibrary.API.Networking.Events;

namespace MinecraftLibrary.API.Networking
{
    public interface INotifyConnectedAndDisconnected
    {
        event EventHandler<ConnectedEventArgs> Connected;
        event EventHandler<DisconnectedEventArgs> DisconnectedEvent;
    }
    


}
