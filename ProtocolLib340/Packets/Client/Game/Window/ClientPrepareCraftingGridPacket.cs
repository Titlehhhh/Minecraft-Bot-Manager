using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.IO;


namespace ProtocolLib340.Packets.Client.Game
{

    
    public class ClientPrepareCraftingGridPacket : IPacket
    {
        public void Read(IMinecraftStreamReader stream)
        {
            
        }

        //out.writeByte(this.windowId);
        //out.writeVarInt(this.recipeId);
        //out.WriteBooleanean(this.makeAll);
        public void Write(IMinecraftStreamWriter stream)
        {
            
        }
    }
}
