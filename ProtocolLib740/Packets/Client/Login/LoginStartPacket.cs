using MinecraftLibrary.API;
using MinecraftLibrary.API.IO;
using MinecraftLibrary.API.Networking;

namespace ProtocolLib754.Packets.Client
{
    [MinecraftLibrary.API.Protocol.PacketInfo(0x00, 740, PacketCategory.Login, PacketSide.Client)]
    public class LoginStartPacket : IPacket
    {
        public string Nickname { get; set; }
        public void Write(IMinecraftStreamWriter stream)
        {
            stream.WriteString(Nickname);
        }

        public void Read(IMinecraftStreamReader stream)
        {

        }

        public LoginStartPacket(string nickname)
        {
            Nickname = nickname;
        }
        public LoginStartPacket()
        {

        }
    }
}
