using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Client.Game
{

    [PacketInfo(0x0B, 340, PacketSide.Client, PacketCategory.Game)]
    public class ClientKeepAlivePacket : MinecraftPacket
    {
        public long ID { get; set; }
        //out.writeLong(this.id);
        public override void Write(IMinecraftStreamWriter output)
        {
            output.WriteLong(ID);
        }

        public ClientKeepAlivePacket(long iD)
        {
            ID = iD;
        }
    }
}
