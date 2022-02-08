using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Protocol.Helpres;

namespace ProtocolLib340.Packets.Client.Game.Window
{

    [PacketMeta(0x06, 340, PacketSide.Client, PacketCategory.Game)]
    public class ClientEnchantItemPacket : MinecraftPacket
    {
        //out.writeByte(this.windowId);
       //out.writeByte(this.enchantment);
        public override void Write(IMinecraftStreamWriter output)
        {
            
        }
    }
}
