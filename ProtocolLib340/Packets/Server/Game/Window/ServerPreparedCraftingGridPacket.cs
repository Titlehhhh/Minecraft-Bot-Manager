using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Server.Game.Window
{

    [PacketHeader(0x2B, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerPreparedCraftingGridPacket : IPacket
    {
        //this.windowId = in.readByte();
       //this.recipeId = in.readVarInt();
        public void Read(MinecraftStream stream)
        {
            
        }

        public void Write(MinecraftStream stream)
        {
            
        }

        public ServerPreparedCraftingGridPacket() {}
    }

}
