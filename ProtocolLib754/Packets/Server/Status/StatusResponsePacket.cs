using MinecraftLibrary.API;
using MinecraftLibrary.API.IO;
using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Protocol;

namespace ProtocolLib754.Packets.Server.Status
{
    [PacketInfo(0x00, 754, PacketCategory.Status, PacketSide.Server)]
    public class StatusResponsePacket : IPacket
    {
        public ServerInfo ServerStatusInfo { get; set; }

        public void Read(IMinecraftStreamReader stream)
        {

        }

        public void Write(IMinecraftStreamWriter stream)
        {

        }
    }
}
