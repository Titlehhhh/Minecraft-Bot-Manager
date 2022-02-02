using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Protocol.Helpres;

namespace PacketPallete340.Packets.Client.Game.Window
{

    [PacketMeta(0x12, 340, PacketSide.Client, PacketCategory.Game)]
    public class ClientPrepareCraftingGridPacket : ClientPacket
    {
        //out.writeByte(this.windowId);
       //out.writeVarInt(this.recipeId);
       //out.writeBoolean(this.makeAll);
        public override void Write(MinecraftStream output)
        {
            
        }
    }
}
