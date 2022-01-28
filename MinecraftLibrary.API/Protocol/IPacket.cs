using MinecraftLibrary.API.Networking.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftLibrary.API.Protocol
{
    public interface IPacket
    {
        void Read(NetInput input);
        void Write(NetOutput output);
    }
    
}
