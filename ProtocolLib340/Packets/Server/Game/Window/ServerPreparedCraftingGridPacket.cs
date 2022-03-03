using MinecraftLibrary.API.IO;
using MinecraftLibrary.API.Networking;


namespace ProtocolLib340.Packets.Server
{


    public class ServerPreparedCraftingGridPacket : IPacket
    {
        //this.windowId = in.readByte();
        //this.recipeId = in.readVarInt();
        public void Read(IMinecraftStreamReader stream)
        {

        }

        public void Write(IMinecraftStreamWriter stream)
        {

        }

        public ServerPreparedCraftingGridPacket() { }
    }

}
