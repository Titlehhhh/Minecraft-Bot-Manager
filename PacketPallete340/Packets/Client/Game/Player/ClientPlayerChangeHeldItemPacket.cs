using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Protocol.Helpres;

namespace PacketPallete340.Packets.Client.Game.Player
{

    [PacketMeta(0x1A, 340, PacketSide.Client, PacketCategory.Game)]
    public class ClientPlayerChangeHeldItemPacket : ClientPacket
    {
        //out.writeShort(this.slot);
        public override void Write(MinecraftStream output)
        {
            
        }
    }
}
