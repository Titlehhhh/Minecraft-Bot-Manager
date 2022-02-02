using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Protocol.Helpres;

namespace PacketPallete340.Packets.Client.Game.Window
{
    //out.writeVarInt(MagicValues.value(Integer.class, this.type));
    //switch(this.type) {
    //case DISPLAYED_RECIPE:
    //out.writeInt(this.recipeId);
    //break;
    //case CRAFTING_BOOK_STATUS:
    //out.writeBoolean(this.craftingBookOpen);
    //out.writeBoolean(this.filterActive);
    //break;
    //default:
    //throw new IOException("Unknown crafting book data type: " + this.type);
    //}
    [PacketMeta(0x17, 340, PacketSide.Client, PacketCategory.Game)]
    public class ClientCraftingBookDataPacket : ClientPacket
    {
        public override void Write(MinecraftStream output, int version)
        {
            
        }
    }
}
