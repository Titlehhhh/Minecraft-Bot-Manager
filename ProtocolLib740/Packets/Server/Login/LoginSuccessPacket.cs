using MinecraftLibrary.API;
using MinecraftLibrary.API.IO;
using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Protocol;

namespace ProtocolLib740.Packets.Server
{
    [PacketInfo(0x02, 740, PacketCategory.Login, PacketSide.Server)]
    public class LoginSuccessPacket : IPacket
    {
        public string UUID { get; set; }
        public string Username { get; set; }

        public void Read(IMinecraftStreamReader stream)
        {
            UUID = stream.ReadString();
            Username = stream.ReadString();
        }

        public void Write(IMinecraftStreamWriter stream)
        {

        }
        public LoginSuccessPacket()
        {

        }
    }
}
