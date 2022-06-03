using McProtoNet.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftBotManager.Domain
{
    
    public interface IMinecaftClient : IDisposable
    {
        IPacketReaderWriter Protocol { get; }

        void SendChatMessage(string message);

        IMove Move { get; }

        IWorld World { get; }
    }
}
