using MinecraftLibrary.API;
using MinecraftLibrary.API.IO;
using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Protocol;

namespace ProtocolLib754.Packets.Server
{
    [PacketInfo(0x03, 740, PacketCategory.Login, PacketSide.Server)]
    public class LoginSetCompressionPacket : IPacket
    {
        public int Threshold { get; set; }

        public void Read(IMinecraftStreamReader stream)
        {
            Threshold = stream.ReadVarInt();
        }

        public void Write(IMinecraftStreamWriter stream)
        {

        }
        public LoginSetCompressionPacket()
        {

        }
    }
}
