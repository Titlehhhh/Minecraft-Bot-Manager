using MinecraftLibrary.API.Networking.IO;

namespace MinecraftLibrary.API.Networking.Events
{
    public class PacketReceivedEventArgs : EventArgs
    {
        public int ID { get; private set; }
        public IPacket packet{ get; private set; }

        public PacketReceivedEventArgs(int iD, IPacket packet)
        {
            ID = iD;
            this.packet = packet;
        }
    }
}
