using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Protocol.Helpres;

namespace PacketPallete340.Packets.Client.Game.Player
{
    //NetUtil.writePosition(out, this.position);
    //out.writeVarInt(MagicValues.value(Integer.class, this.face));
    //out.writeVarInt(MagicValues.value(Integer.class, this.hand));
    //out.writeFloat(this.cursorX);
    //out.writeFloat(this.cursorY);
    //out.writeFloat(this.cursorZ);
    [PacketMeta(0x1F, 340, PacketSide.Client, PacketCategory.Game)]
    public class ClientPlayerPlaceBlockPacket : ClientPacket
    {
        public override void Write(MinecraftStream output, int version)
        {
            
        }
    }
}
