using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MinecraftLibrary.API.Protocol;

namespace ProtocolLib740
{
    public sealed class PacketProvider740 : IPacketProvider
    {
        public IPacketProviderClient ClientPackets { get; private set; }

        public IPacketProviderServer ServerPackets { get; private set; }

        public PacketProvider740()
        {

        }
    }
}
