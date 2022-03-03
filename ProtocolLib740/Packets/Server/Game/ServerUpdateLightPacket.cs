using MinecraftLibrary.API;
using MinecraftLibrary.API.IO;
using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Protocol;


namespace ProtocolLib740.Packets.Server
{

    [PacketInfo(0x23, 740, PacketCategory.Game, PacketSide.Server)]
    public class ServerUpdateLightPacket : IPacket
    {
        public void Write(IMinecraftStreamWriter stream)
        {

        }
        public void Read(IMinecraftStreamReader stream)
        {

        }
        public ServerUpdateLightPacket() { }
    }
}

