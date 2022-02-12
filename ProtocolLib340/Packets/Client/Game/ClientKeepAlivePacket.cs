using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Client.Game
{

    [PacketHeader(0x0B, 340, PacketSide.Client, PacketCategory.Game)]
    public class ClientKeepAlivePacket : IPacket
    {
        public long ID { get; set; }
        //out.writeLong(this.id);
        public void Write(MinecraftStream stream)
        {
            stream.WriteLong(ID);
        }

        public void Read(MinecraftStream stream)
        {
            
        }

        public ClientKeepAlivePacket(long iD)
        {
            ID = iD;
        }
    }
}
