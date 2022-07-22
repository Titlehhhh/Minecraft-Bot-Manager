using McProtoNet.Core.Protocol;
using System.ComponentModel;

namespace MinecraftBotManager.Core
{
    public delegate void GameKickedHandler(string reason);
    public delegate void LoginRejectedHandler(string reason);
    public delegate void OnErrorHandler(Exception exception);
    public delegate void PacketReceivedHandler(Packet packet);
    public delegate void PacketSentingHandler(Packet packet);
    public delegate void PacketSentedHandler(Packet packet);
   // public delegate void 


    public interface IMinecraftClient : INotifyPropertyChanged, IDisposable
    {
        event GameKickedHandler GameKicked;
        event LoginRejectedHandler LoginRejected;
        event OnErrorHandler OnError;
        event PacketReceivedHandler PacketReceived;
        event PacketSentingHandler PacketSenting;
        event PacketSentedHandler PacketSented;

        int TargetProtocolVersion { get; }

        void QueuePacket(Packet packet);

        void Login(string serverName = "", ushort port = 0);

        void Close();
    }
}
