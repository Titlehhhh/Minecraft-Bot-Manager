using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtocolLib340.Packets.Client.Login
{
    [PacketInfo(0x00,340,PacketSide.Client,PacketCategory.Login)]
    public class LoginStartPacket : MinecraftPacket
    {
        public string Nickname { get; set; }
        public override void Write(IMinecraftStreamWriter output)
        {
            output.WriteString(Nickname);
        }

        public LoginStartPacket(string nickname)
        {
            Nickname = nickname;
        }
    }
}
