using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Helpres;
using MinecraftLibrary.Core.Protocol.Attributes;

namespace MinecraftLibrary.Core.Protocol.Packets.Client.Login
{
    [PacketMetaLogin(0x00)]
    public class LoginStartPacket : ClientPacket
    {
        public string UserName { get; set; }
        public LoginStartPacket(string user)
        {
            UserName = user;
        }
        public override void Write(MinecraftStream output, int version)
        {
            output.WriteString(UserName);
        }
    }
}
