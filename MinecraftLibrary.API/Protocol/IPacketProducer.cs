using MinecraftLibrary.API.Networking;
using System.Collections.Concurrent;

namespace MinecraftLibrary.API.Protocol
{
    public interface IPacketProducer
    {        
        bool TryGetInputPacket(int id,out Lazy<IPacket> packet);
        bool TryGetOutputId(Type Tpacket, out int id);
    }
}
