using MinecraftLibrary.API.Networking.IO;

namespace MinecraftLibrary.API.Networking.Events
{
    public class PacketReceivedEventArgs : EventArgs
    {
        public MinecraftStream DataStream{ get; private set; }
        public int PacketID { get; private set; }

        public PacketReceivedEventArgs(MinecraftStream dataStream, int packetID)
        {
            DataStream = dataStream;
            PacketID = packetID;
        }
    }
}
