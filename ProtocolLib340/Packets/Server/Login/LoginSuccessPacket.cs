using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Server.Login
{
    [PacketHeader(0x02, 340, PacketSide.Server, PacketCategory.Login)]
    public class LoginSuccessPacket : IPacket
    {
        public Guid UUID { get; set; }
        public string Username { get; set; }
        public void Read(MinecraftStream stream)
        {
            UUID = stream.ReadGuid();
            Username = stream.ReadString();
        }

        public void Write(MinecraftStream stream)
        {
            
        }

        public LoginSuccessPacket(Guid uUID, string username)
        {
            UUID = uUID;
            Username = username;
        }

        public LoginSuccessPacket() { }
    }
}
