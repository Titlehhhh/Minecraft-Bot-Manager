using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Protocol.Helpres;

namespace PacketPallete340.Packets.Client.Game
{

    [PacketMeta(0x0B, 340, PacketSide.Client, PacketCategory.Game)]
    public class ClientKeepAlivePacket : ClientPacket
    {
        public long ID { get; set; }
        //out.writeLong(this.id);
        public override void Write(MinecraftStream output)
        {
            output.WriteLong(ID);
        }

        public ClientKeepAlivePacket(long iD)
        {
            ID = iD;
        }
    }
}
