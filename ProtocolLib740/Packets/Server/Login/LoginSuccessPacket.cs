using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib740.Packets.Server.Login
{
    [PacketHeader(0x02, 740, PacketSide.Server, PacketCategory.Game)]
    public class LoginSuccessPacket : IPacket
    {
        public string UUID { get; set; }
        public string Username { get; set; }

        public void Read(MinecraftStream stream)
        {
            UUID = stream.ReadString();
            Username = stream.ReadString();
        }

        public void Write(MinecraftStream stream)
        {

        }
        public LoginSuccessPacket()
        {

        }
    }
}
