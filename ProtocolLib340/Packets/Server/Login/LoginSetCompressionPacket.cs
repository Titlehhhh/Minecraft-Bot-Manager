using MinecraftLibrary.API.IO;
using MinecraftLibrary.API.Networking;

namespace ProtocolLib340.Packets.Server
{

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

        public LoginSetCompressionPacket(int threshold)
        {
            Threshold = threshold;
        }

        public LoginSetCompressionPacket() { }
    }
}
