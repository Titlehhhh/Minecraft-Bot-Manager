using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Server.Login
{
    [PacketInfo(0x02, 340, PacketSide.Server, PacketCategory.Login)]
    public class LoginSuccessPacket : IPacket
    {
        public Guid UUID { get; set; }
        public string Username { get; set; }
        public void Read(MinecraftStream stream)
        {
            UUID = stream.ReadUUID();
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
