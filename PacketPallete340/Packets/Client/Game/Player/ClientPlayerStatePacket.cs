using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Protocol.Helpres;

namespace PacketPallete340.Packets.Client.Game.Player
{
    //out.writeVarInt(this.entityId);
    //out.writeVarInt(MagicValues.value(Integer.class, this.state));
    //out.writeVarInt(this.jumpBoost);
    [PacketMeta(0x15, 340, PacketSide.Client, PacketCategory.Game)]
    public class ClientPlayerStatePacket : ClientPacket
    {
        public override void Write(MinecraftStream output, int version)
        {
            
        }
    }
}
