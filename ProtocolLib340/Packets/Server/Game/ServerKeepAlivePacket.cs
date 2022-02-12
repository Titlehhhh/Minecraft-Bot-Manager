using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Server.Game
{

    [PacketHeader(0x1F, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerKeepAlivePacket : IPacket
    {
        public long ID { get; set; }
        
        public void Read(MinecraftStream stream)
        {
            ID = stream.ReadLong();
        }

        public void Write(MinecraftStream stream)
        {
            
        }

        public ServerKeepAlivePacket(long iD)
        {
            ID = iD;
        }

        public ServerKeepAlivePacket() {}
    }

}
