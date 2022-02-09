using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Events;
using MinecraftLibrary.API.Networking.Proxy;
using MinecraftLibrary.API.Protocol.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftLibrary.API.Protocol
{

    public interface IPacketReader : IDisposable
    {
        Dictionary<Type, int> RegisteredOutputPakets { get; set; }
        Dictionary<int, Type> RegisteredInputPakets { get; set; }
        void RegisterPacketInput(int id, Type t);
        bool UnRegisterPacketInput(int id);
        event EventHandler<PacketProcessedEventArgs> PacketProcessedEvent;
    }

}
