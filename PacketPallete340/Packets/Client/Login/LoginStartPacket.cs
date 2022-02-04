using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Protocol.Helpres;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacketPallete340.Packets.Client.Login
{
    [PacketMeta(0x00,340,PacketSide.Client,PacketCategory.Login)]
    public class LoginStartPacket : MinecraftPacket
    {
        public string Nickname { get; set; }
        public override void Write(MinecraftStream output)
        {
            output.WriteString(Nickname);
        }

        public LoginStartPacket(string nickname)
        {
            Nickname = nickname;
        }
    }
}
