using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Protocol.Helpres;

namespace ProtocolLib340.Packets.Client.Game.Window
{

    [PacketMeta(0x12, 340, PacketSide.Client, PacketCategory.Game)]
    public class ClientPrepareCraftingGridPacket : MinecraftPacket
    {
        //out.writeByte(this.windowId);
       //out.writeVarInt(this.recipeId);
       //out.writeBoolean(this.makeAll);
        public override void Write(IMinecraftStreamWriter output)
        {
            
        }
    }
}
