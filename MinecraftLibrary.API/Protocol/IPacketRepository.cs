using MinecraftLibrary.API.Networking;

namespace MinecraftLibrary.API.Protocol
{
    public interface IPacketRepository
    {
        public Dictionary<int, ILazyPacket<IPacket>> InputPackets { get; }
        public Dictionary<Type, int> OutputPackets { get; }

        void RegisterPacketInput<TPacket>(int id) where TPacket : IPacket;
        void RegisterPacketOutput(Type type, int id);
        
        void UnregisterPacketInput<TPacket>(int id);
        void UnregisterPacketOutput(int id);



        void Clear();
        bool Remove(int id);
    }


    public interface IPacketProvider
    {

    }


}
