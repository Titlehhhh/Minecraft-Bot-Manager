using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib740.Packets.Server.Login
{
    [PacketHeader(0x03, 740, PacketSide.Server, PacketCategory.Game)]
    public class LoginSetCompressionPacket : IPacket
    {
        public int Threshold { get; set; }

        public void Read(MinecraftStream stream)
        {
            Threshold = stream.ReadVarInt();
        }

        public void Write(MinecraftStream stream)
        {

        }
        public LoginSetCompressionPacket()
        {

        }
    }
}
