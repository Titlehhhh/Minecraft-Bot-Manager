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
    [PacketHeader(0x00, 340, PacketSide.Server, PacketCategory.Login)]
    public class LoginDisconnectPacket : IPacket
    {
        public string Message { get; set; }
        public void Read(MinecraftStream stream)
        {
            Message = stream.ReadString();
        }

        public void Write(MinecraftStream stream)
        {
            
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
