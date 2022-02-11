using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Client.Game.Window
{

    [PacketInfo(0x12, 340, PacketSide.Client, PacketCategory.Game)]
    public class ClientPrepareCraftingGridPacket : IPacket
    {
        //out.writeByte(this.windowId);
       //out.writeVarInt(this.recipeId);
       //out.writeBoolean(this.makeAll);
        public override void Write(IMinecraftStreamWriter output)
        {
            
        }
    }
}
