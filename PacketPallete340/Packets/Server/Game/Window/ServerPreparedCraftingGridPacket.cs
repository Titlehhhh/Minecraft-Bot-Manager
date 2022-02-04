using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Protocol.Helpres;

namespace PacketPallete340.Packets.Server.Game.Window
{

    [PacketMeta(0x2B, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerPreparedCraftingGridPacket : MinecraftPacket
    {
        //this.windowId = in.readByte();
       //this.recipeId = in.readVarInt();
        public override void Read(MinecraftStream output)
        {
            
        }
        public ServerPreparedCraftingGridPacket() {}
    }

}
