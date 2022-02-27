using MinecraftLibrary.API.Networking;

namespace MinecraftLibrary.API.Protocol
{
    public interface IPacketRepository
    {
        Dictionary<int,Lazy<IPacket>> Packets { get; }

        bool TryGetPacket(int id, out IPacket packet);

        void RegisterPacket<TPacket>(int id) where TPacket : IPacket,new();
        void UnRegisterPacket(int id);

        event EventHandler<RegisterPacketEventArgs> PacketRegistered;
        event EventHandler<UnRegisterPacketEventArgs> UnregisterPacket;
    }   

}
