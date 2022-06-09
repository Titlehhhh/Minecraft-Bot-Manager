
using McProtoNet.Core;

namespace MinecraftBotManager.Core
{

    public interface IMinecraftClient : IDisposable
    {
        IPacketReaderWriter Protocol { get; }

        void SendChatMessage(string message);

        IMove Move { get; }

        IWorld World { get; }
    }
}
