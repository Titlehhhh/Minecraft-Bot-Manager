using MinecraftLibrary.API;
using MinecraftLibrary.API.IO;
using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Protocol;


namespace ProtocolLib740.Packets.Server
{

    [PacketInfo(0x3C, 740, PacketCategory.Game, PacketSide.Server)]
    public class ServerAdvancementTabPacket : IPacket
    {
        public void Write(IMinecraftStreamWriter stream)
        {

        }
        public void Read(IMinecraftStreamReader stream)
        {

        }
        public ServerAdvancementTabPacket() { }
    }
}

