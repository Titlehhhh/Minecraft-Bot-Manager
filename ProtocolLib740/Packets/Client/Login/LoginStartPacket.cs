using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib740.Packets.Client.Login
{
    [PacketHeader(0x00, 740, PacketSide.Client, PacketCategory.Login)]
    public class LoginStartPacket : IPacket
    {
        public string Nickname { get; set; }
        public void Write(MinecraftStream stream)
        {
            stream.WriteString(Nickname);
        }

        public void Read(MinecraftStream stream)
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
