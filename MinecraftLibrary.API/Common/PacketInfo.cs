using MinecraftLibrary.API.Networking.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftLibrary.API.Common
{
    public struct PacketInfo
    {
        public int ID { get; private set; }
        public Type TPacket { get; private set; }
        public PacketCategory Category { get; private set; }

        public PacketInfo(int iD, Type tPacket, PacketCategory category)
        {
            ID = iD;
            TPacket = tPacket;
            Category = category;
        }
    }
}
