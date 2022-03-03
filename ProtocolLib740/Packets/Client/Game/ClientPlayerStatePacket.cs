using MinecraftLibrary.API;
using MinecraftLibrary.API.IO;
using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Protocol;


namespace ProtocolLib740.Packets.Client
{

    [PacketInfo(0x1C, 740, PacketCategory.Game, PacketSide.Client)]    public class ClientPlayerStatePacket : IPacket
    {
        public void Write(IMinecraftStreamWriter stream)
        {

        }
        public void Read(IMinecraftStreamReader stream)
        {

        }
        public ClientPlayerStatePacket() { }
    }
}

