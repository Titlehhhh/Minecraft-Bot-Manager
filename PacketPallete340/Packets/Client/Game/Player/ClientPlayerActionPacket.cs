using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Protocol.Helpres;

namespace PacketPallete340.Packets.Client.Game.Player
{

    [PacketMeta(0x14, 340, PacketSide.Client, PacketCategory.Game)]
    public class ClientPlayerActionPacket : ClientPacket
    {
        //out.writeVarInt(MagicValues.value(Integer.class, this.action));
       //NetUtil.writePosition(out, this.position);
       //out.writeByte(MagicValues.value(Integer.class, this.face));
        public override void Write(MinecraftStream output)
        {
            
        }
    }
}
