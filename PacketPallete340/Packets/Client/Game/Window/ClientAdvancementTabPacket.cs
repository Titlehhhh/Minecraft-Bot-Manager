using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Protocol.Helpres;

namespace PacketPallete340.Packets.Client.Game.Window
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
    [PacketMeta(0x19, 340, PacketSide.Client, PacketCategory.Game)]
    public class ClientAdvancementTabPacket : ClientPacket
    {
        public override void Write(MinecraftStream output, int version)
        {
            
        }
    }
}
