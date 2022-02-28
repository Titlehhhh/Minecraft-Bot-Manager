using MinecraftLibrary.API.Networking;

namespace MinecraftLibrary.API.Protocol
{
    public interface IPacketRepository
    {
        Dictionary<int,Lazy<IPacket>> InputPackets { get; }
        Dictionary<Type,int> OutputPackets { get; }

        bool TryGetId(Type Tpacket, out int id);
        void RegisterOutputPacket<TPacket>(int id) where TPacket : IPacket;
        void UnRegisterOutputPacket(Type t);

        bool TryGetPacket(int id, out IPacket packet);
        void RegisterInputPacket<TPacket>(int id) where TPacket : IPacket,new();
        void UnRegisterInputPacket(int id);

        void ClearAll();
        
        event EventHandler<RegisterPacketEventArgs> PacketRegistered;
        event EventHandler<UnRegisterPacketEventArgs> UnregisterPacket;
    }
    public interface IPacketProvider
    {
        Dictionary<int,Type> ServerPacketsStatus { get; }
        Dictionary<int,Type> ServerPacketsLogin { get; }
        Dictionary<int,Type> ServerPacketsGame { get; }
    }

}
