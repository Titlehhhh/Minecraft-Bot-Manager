using MinecraftLibrary.API.Networking.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftLibrary.API.Protocol.Events
{
    public class PacketReceivedEventArgs : EventArgs
    {
        public MinecraftStream DataStream{ get; private set; }
        public int PacketID { get; private set; }

        public PacketReceivedEventArgs(MinecraftStream dataStream, int packetID)
        {
            DataStream = dataStream;
            PacketID = packetID;
        }
    }
}
