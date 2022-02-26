using MinecraftLibrary.API.Networking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftLibrary.Networking
{
    public class PacketSendEventArgs : EventArgs
    {
        public IPacket Packet { get; private set; }
        public PacketSendEventArgs(IPacket packet)
        {
            Packet = packet;
        }
    }
}
