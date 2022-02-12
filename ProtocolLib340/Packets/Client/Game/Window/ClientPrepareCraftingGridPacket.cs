using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Client.Game.Window
{

    [PacketHeader(0x12, 340, PacketSide.Client, PacketCategory.Game)]
    public class ClientPrepareCraftingGridPacket : IPacket
    {
        public void Read(MinecraftStream stream)
        {
            
        }

        //out.writeByte(this.windowId);
        //out.writeVarInt(this.recipeId);
        //out.WriteBooleanean(this.makeAll);
        public void Write(MinecraftStream stream)
        {
            
        }
    }
}
