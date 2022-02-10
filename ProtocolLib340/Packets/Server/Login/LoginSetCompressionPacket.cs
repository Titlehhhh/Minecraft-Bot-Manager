using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Server.Login
{
    [PacketInfo(0x03, 340, PacketSide.Server, PacketCategory.Login)]
    public class LoginSetCompressionPacket : MinecraftPacket
    {
        public int Threshold { get; set; }
        public override void Read(IMinecraftStreamReader input)
        {
            Threshold = input.ReadNextVarInt();
        }

        public LoginSetCompressionPacket(int threshold)
        {
            Threshold = threshold;
        }

        public LoginSetCompressionPacket() { }
    }
}
