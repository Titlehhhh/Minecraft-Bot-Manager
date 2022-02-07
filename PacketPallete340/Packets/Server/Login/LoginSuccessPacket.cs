using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Protocol.Helpres;

namespace PacketPallete340.Packets.Server.Login
{
    [PacketMeta(0x02, 340, PacketSide.Server, PacketCategory.Login)]
    public class LoginSuccessPacket : MinecraftPacket
    {
        public Guid UUID { get; set; }
        public string Username { get; set; }
        public override void Read(IMinecraftStreamReader input)
        {
            UUID = input.ReadNextUUID();
            Username = input.ReadNextString();
        }
        public LoginSuccessPacket(Guid uUID, string username)
        {
            UUID = uUID;
            Username = username;
        }

        public LoginSuccessPacket() { }
    }
}
