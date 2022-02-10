using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtocolLib340.Packets.Server.Login
{
    [PacketInfo(0x00, 340, PacketSide.Server, PacketCategory.Login)]
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
