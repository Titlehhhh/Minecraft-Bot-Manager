using MinecraftLibrary.API.Common;
using MinecraftLibrary.API.Networking.Attributes;

namespace MinecraftLibrary.API.Interfaces
{
    public interface IPacketProvider
    {
        List<PacketInfo> GetServerPackets();
        List<PacketInfo> GetClientPackets();

        Dictionary<int,Type> GetServerPackets(PacketCategory category);
        Dictionary<Type,int> GetClientPackets(PacketCategory category);


    }

}
