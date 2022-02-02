using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Protocol.Helpres;

namespace PacketPallete340.Packets.Client.Game.Window
{
    //out.writeShort(this.slot);
    //NetUtil.writeItem(out, this.clicked);
    [PacketMeta(0x1B, 340, PacketSide.Client, PacketCategory.Game)]
    public class ClientCreativeInventoryActionPacket : ClientPacket
    {
        public override void Write(MinecraftStream output, int version)
        {
            
        }
    }
}
