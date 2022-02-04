using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Protocol.Helpres;

namespace PacketPallete340.Packets.Client.Game.Window
{

    [PacketMeta(0x19, 340, PacketSide.Client, PacketCategory.Game)]
    public class ClientAdvancementTabPacket : MinecraftPacket
    {
        //out.writeVarInt(MagicValues.value(Integer.class, this.action));
       //switch(this.action) {
       //case CLOSED_SCREEN:
       //break;
       //case OPENED_TAB:
       //out.writeString(this.tabId);
       //break;
       //default:
       //throw new IOException("Unknown advancement tab action: " + this.action);
       //}
        public override void Write(MinecraftStream output)
        {
            
        }
    }
}
