using MinecraftLibrary.API.Networking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftLibrary.API.Protocol
{
    public class UnRegisterPacketEventArgs : EventArgs
    {
        public Type Packet { get; private set; }

        public UnRegisterPacketEventArgs(Type packet)
        {
            Packet = packet;
        }
    }
}
