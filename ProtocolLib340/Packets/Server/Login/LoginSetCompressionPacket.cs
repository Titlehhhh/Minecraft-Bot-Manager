using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Server.Login
{
    [PacketInfo(0x03, 340, PacketSide.Server, PacketCategory.Login)]
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

        public LoginSetCompressionPacket(int threshold)
        {
            Threshold = threshold;
        }

        public LoginSetCompressionPacket() { }
    }
}
