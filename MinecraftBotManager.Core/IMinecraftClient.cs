using McProtoNet.Core.Protocol;
using System.ComponentModel;

namespace MinecraftBotManager.Core
{
    public delegate void GameKickedHandler(string reason);
    public delegate void LoginRejectedHandler(string reason);
    //public delegate void OnErrorHandler(Exception exception);


    public interface IMinecraftClient : INotifyPropertyChanged, IDisposable
    {


        int TargetProtocolVersion { get; }

        void QueuePacket(Packet packet);

        void Start(string serverName = "", ushort port = 0);

        void Close();
    }
}
