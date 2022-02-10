using System;

namespace MinecraftLibrary.API.Networking.Events
{
    public class PacketSentEventArgs : EventArgs
    {
        public IPacket Packet { get; private set; }
        public PacketSentEventArgs(IPacket packet)
        {
            Packet = packet;
        }
    }
}
