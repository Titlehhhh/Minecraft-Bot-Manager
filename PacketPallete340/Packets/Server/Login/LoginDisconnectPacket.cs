using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Protocol.Helpres;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacketPallete340.Packets.Server.Login
{
    [PacketMeta(0x00, 340, PacketSide.Server, PacketCategory.Login)]
    public class LoginDisconnectPacket : MinecraftPacket
    {
        public string Message { get; set; }
        public override void Read(IMinecraftStreamReader input)
        {
            Message = input.ReadNextString();
        }
        public LoginDisconnectPacket()
        {

        }

        public LoginDisconnectPacket(string message)
        {
            Message = message;
        }
    }
}
