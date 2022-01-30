using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftLibrary.API.Protocol.Events
{
    public class PacketProcessedEventArgs : EventArgs
    {
        public IPacket Packet { get; private set; }

        public PacketProcessedEventArgs(IPacket packet)
        {
            Packet = packet;
        }
    }
}
