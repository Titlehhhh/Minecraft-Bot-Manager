using System.Collections.Concurrent;

namespace MinecraftLibrary.API.Networking
{
    public interface IPacketFilter
    {
        ConcurrentDictionary<int, Type> ServerPackets { get; set; }
        ConcurrentDictionary<Type, int> ClientPackets { get; set; }

        
    }
}
