using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftLibrary.API.Protocol
{
    public interface IPacketManager
    {
        int TargetVersion { get; }
        Dictionary<int, Type> InputPackets { get; }
        Dictionary<int,Type> OutputPackets { get; }
    }
}
