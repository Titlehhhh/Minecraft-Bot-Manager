using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Protocol.Helpres;

namespace PacketPallete340.Packets.Client.Game.Window
{

    [PacketMeta(0x1B, 340, PacketSide.Client, PacketCategory.Game)]
    public class ClientCreativeInventoryActionPacket : ClientPacket
    {
        //out.writeShort(this.slot);
        //NetUtil.writeItem(out, this.clicked);
        public override void Write(MinecraftStream output)
        {

        }
    }
}