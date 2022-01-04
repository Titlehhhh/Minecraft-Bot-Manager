using MinecraftProtocol.IO;
using MinecraftProtocol.Packets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftLibrary.MinecraftProtocol.Packets.Client.Game
{
    public class ClientKeepAlivePacket : ClientPacket
    {
        public long PingId;
        public ClientKeepAlivePacket(long id)
        {
            PingId = id;
        }       

        public void Write(NetOutput output,int protocolversion)
        {
            output.WriteLong(PingId);
        }
    }

}
