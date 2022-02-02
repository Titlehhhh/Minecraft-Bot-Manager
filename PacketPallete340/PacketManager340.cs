using MinecraftLibrary.API.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacketPallete340
{
    public class PacketManager340 : IPacketManager
    {
        public int TargetVersion => 340;

        public Dictionary<int, Type> InputPackets => null;

        public Dictionary<int, Type> OutputPackets => null;
        public PacketManager340()
        {

        }
    }
}
