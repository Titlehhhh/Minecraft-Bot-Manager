using MinecraftLibrary.API;
using MinecraftLibrary.API.IO;
using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Protocol;


namespace ProtocolLib754.Packets.Server
{

    [PacketInfo(0x14, 740, PacketCategory.Game, PacketSide.Server)]
    public class ServerWindowPropertyPacket : IPacket
    {
        public void Write(IMinecraftStreamWriter stream)
        {

        }
        public void Read(IMinecraftStreamReader stream)
        {

        }
        public ServerWindowPropertyPacket() { }
    }
}

