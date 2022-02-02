using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Protocol.Helpres;

namespace PacketPallete340.Packets.Client.Game.Player
{
    //out.writeVarInt(MagicValues.value(Integer.class, this.hand));
    [PacketMeta(0x20, 340, PacketSide.Client, PacketCategory.Game)]
    public class ClientPlayerUseItemPacket : ClientPacket
    {
        public override void Write(MinecraftStream output, int version)
        {
            
        }
    }
}
