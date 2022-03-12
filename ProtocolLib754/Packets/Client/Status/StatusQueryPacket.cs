using MinecraftLibrary.API;
using MinecraftLibrary.API.IO;
using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtocolLib754.Packets.Client.Status
{
    [PacketInfo(0x00,754,PacketCategory.Status,PacketSide.Client)]
    public class StatusQueryPacket : IPacket
    {
        public void Read(IMinecraftStreamReader stream)
        {
           
        }

        public void Write(IMinecraftStreamWriter stream)
        {
            
        }
    }
    
}
