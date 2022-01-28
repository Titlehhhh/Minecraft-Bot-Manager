using System;

namespace MinecraftLibrary.API.Networking.Events
{
    public class PacketReceivedEventArgs : EventArgs
    {
        public ByteBlock Data{ get; private set; }

        public PacketReceivedEventArgs(ByteBlock data)
        {
            Data = data;
        }
    }    
}

