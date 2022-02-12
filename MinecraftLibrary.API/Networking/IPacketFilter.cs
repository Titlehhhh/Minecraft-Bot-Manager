namespace MinecraftLibrary.API.Networking
{
    public interface IPacketFilter
    {
        Dictionary<int, Type> ServerPackets { get; set; }
        Dictionary<Type, int> ClientPackets { get; set; }

        void RegisterClientPacket(int id, Type value);
        void RegisterrClientPacket<TPacket>(int id) where TPacket : IPacket;

        void UnregisterClientPacket<TPacket>();
        void UnregisterClientPacket(int id);

        void RegisterServerPacket(int id, Type value);
        void RegisterServerPacket<TPacket>(int id) where TPacket : IPacket;

        void UnregisterServerPacket(Type key);
        void UnregisterServerPacket<TPacket>() where TPacket : IPacket;
        void UnregisterServerPacket(int id);


    }
}
