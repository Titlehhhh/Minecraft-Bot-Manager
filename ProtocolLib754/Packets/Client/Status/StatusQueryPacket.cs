using MinecraftLibrary.API;
using MinecraftLibrary.API.IO;
using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Protocol;

namespace ProtocolLib754.Packets.Client
{
    [PacketInfo(0x00, 754, PacketCategory.Status, PacketSide.Client)]
    public class StatusQueryPacket : IPacket
    {
        public void Read(IMinecraftStreamReader stream)
        {

        }

        public void Write(IMinecraftStreamWriter stream)
        {

        }
    }

}
