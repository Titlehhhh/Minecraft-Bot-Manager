using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.IO;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtocolLib340.Packets.Client.Login
{
    
    public class LoginStartPacket : IPacket
    {
        public string Nickname { get; set; }
        public void Write(IMinecraftStreamWriter stream)
        {
            stream.WriteString(Nickname);
        }

        public void Read(IMinecraftStreamReader stream)
        {
            
        }

        public LoginStartPacket(string nickname)
        {
            Nickname = nickname;
        }
        public LoginStartPacket()
        {

        }
    }
}
