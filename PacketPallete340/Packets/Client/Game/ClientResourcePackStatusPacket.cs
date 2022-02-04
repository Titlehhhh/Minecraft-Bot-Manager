using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Protocol.Helpres;

namespace PacketPallete340.Packets.Client.Game
{

    [PacketMeta(0x18, 340, PacketSide.Client, PacketCategory.Game)]
    public class ClientResourcePackStatusPacket : MinecraftPacket
    {
        //out.writeVarInt(MagicValues.value(Integer.class, this.status));
        public override void Write(MinecraftStream output)
        {
            
        }
    }
}
