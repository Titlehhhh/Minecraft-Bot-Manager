using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Protocol.Helpres;

namespace PacketPallete340.Packets.Client.Game.Window
{
    //out.writeByte(this.windowId);
    //out.writeByte(this.enchantment);
    [PacketMeta(0x06, 340, PacketSide.Client, PacketCategory.Game)]
    public class ClientEnchantItemPacket : ClientPacket
    {
        public override void Write(MinecraftStream output, int version)
        {
            
        }
    }
}
