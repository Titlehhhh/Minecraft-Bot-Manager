using MinecraftLibrary.API.Networking;

namespace MinecraftLibrary.API.Protocol
{
    public interface IPacketManager : IPacketProducer
    {
        Dictionary<int,Lazy<IPacket>> InputPackets { get; }
        Dictionary<Type,int> OutputPackets { get; }
        
        void RegisterOutputPacket<TPacket>(int id) where TPacket : IPacket;
        void RegisterOutputPacket(Type Tpacket, int id);

        void UnRegisterOutputPacket(Type t);
        void UnRegisterOutputPacket<TPacket>() where TPacket : IPacket;

        void RegisterInputPacket<TPacket>(int id) where TPacket : IPacket, new();
        void RegisterInputPacket(Type Tpacket, int id);
        void UnRegisterInputPacket<TPacket>() where TPacket : IPacket;        
        void UnRegisterInputPacket(int id);
        
        void ClearAll();
        void ClearOutputPackets();
        void ClearInputPackets();
        event EventHandler<RegisterPacketEventArgs> PacketRegistered;
        event EventHandler<UnRegisterPacketEventArgs> UnregisterPacket;
    } 
}
