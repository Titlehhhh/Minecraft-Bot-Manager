using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.IO;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtocolLib340.Packets.Server.Login
{
    
    public class LoginDisconnectPacket : IPacket
    {
        public string Message { get; set; }
        public void Read(IMinecraftStreamReader stream)
        {
            Message = stream.ReadString();
        }

        public void Write(IMinecraftStreamWriter stream)
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
