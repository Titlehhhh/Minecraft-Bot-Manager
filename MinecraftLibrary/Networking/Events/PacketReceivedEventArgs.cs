using MinecraftLibrary.API.Networking.IO;

namespace MinecraftLibrary.Networking
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
