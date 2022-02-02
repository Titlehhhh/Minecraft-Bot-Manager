using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Protocol.Helpres;

namespace PacketPallete340.Packets.Client.Game.Player
{

    [PacketMeta(0x1D, 340, PacketSide.Client, PacketCategory.Game)]
    public class ClientPlayerSwingArmPacket : ClientPacket
    {
        //out.writeVarInt(MagicValues.value(Integer.class, this.hand));
        public override void Write(MinecraftStream output)
        {
            
        }
    }
}
