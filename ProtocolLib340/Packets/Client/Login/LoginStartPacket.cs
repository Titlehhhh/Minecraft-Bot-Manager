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
    public class LoginStartPacket : IPacket
    {
        public string Nickname { get; set; }
        public void Write(MinecraftStream stream)
        {
            stream.WriteString(Nickname);
        }

        public void Read(MinecraftStream stream)
        {
            
        }

        public LoginStartPacket(string nickname)
        {
            Nickname = nickname;
        }
    }
}
