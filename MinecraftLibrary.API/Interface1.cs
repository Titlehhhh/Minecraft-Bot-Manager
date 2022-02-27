using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MinecraftLibrary.API.Networking;


namespace MinecraftLibrary.API    
{   

    public interface ILazyPacket<in TPacket> where TPacket : IPacket
    {
        IPacket PacketValue { get; }
    }
}
