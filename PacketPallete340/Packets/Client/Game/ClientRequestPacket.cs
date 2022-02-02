using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Protocol.Helpres;

namespace PacketPallete340.Packets.Client.Game
{
    //out.writeVarInt(MagicValues.value(Integer.class, this.request));
    [PacketMeta(0x03, 340, PacketSide.Client, PacketCategory.Game)]
    public class ClientRequestPacket : ClientPacket
    {
        public override void Write(MinecraftStream output, int version)
        {
            
        }
    }
}
