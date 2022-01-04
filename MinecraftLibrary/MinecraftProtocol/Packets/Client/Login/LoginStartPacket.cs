using MinecraftProtocol.IO;
using MinecraftProtocol.Packets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftLibrary.MinecraftProtocol.Packets.Client.Login
{
    public class LoginStartPacket : ClientPacket
    {
        public string UserName { get; set; }
        public LoginStartPacket(string user)
        {
            UserName = user;
        }


        public void Write(NetOutput output, int protocolversion)
        {
            output.WriteString(UserName);
        }
    }
}
