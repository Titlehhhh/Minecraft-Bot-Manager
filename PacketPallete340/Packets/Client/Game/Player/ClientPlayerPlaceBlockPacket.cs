using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Protocol.Helpres;

namespace PacketPallete340.Packets.Client.Game.Player
{

    [PacketMeta(0x1F, 340, PacketSide.Client, PacketCategory.Game)]
    public class ClientPlayerPlaceBlockPacket : MinecraftPacket
    {
        //NetUtil.writePosition(out, this.position);
        //out.writeVarInt(MagicValues.value(Integer.class, this.face));
        //out.writeVarInt(MagicValues.value(Integer.class, this.hand));
        //out.writeFloat(this.cursorX);
        //out.writeFloat(this.cursorY);
        //out.writeFloat(this.cursorZ);
        public override void Write(IMinecraftStreamWriter output)
        {

        }
    }
}
