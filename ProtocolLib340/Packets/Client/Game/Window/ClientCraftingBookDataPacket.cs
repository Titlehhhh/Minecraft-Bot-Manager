using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Client.Game.Window
{

    [PacketHeader(0x17, 340, PacketSide.Client, PacketCategory.Game)]
    public class ClientCraftingBookDataPacket : IPacket
    {
        public void Read(MinecraftStream stream)
        {
            
        }

        //out.writeVarInt(MagicValues.value(Integer.class, this.type));
        //switch(this.type) {
        //case DISPLAYED_RECIPE:
        //out.writeInt(this.recipeId);
        //break;
        //case CRAFTING_BOOK_STATUS:
        //out.WriteBooleanean(this.craftingBookOpen);
        //out.WriteBooleanean(this.filterActive);
        //break;
        //default:
        //throw new IOException("Unknown crafting book data type: " + this.type);
        //}
        public void Write(MinecraftStream stream)
        {
            
        }
    }
}
