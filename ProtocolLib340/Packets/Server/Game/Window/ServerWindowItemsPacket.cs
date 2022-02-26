using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.IO;


namespace ProtocolLib340.Packets.Server.Game.Window
{

    
    public class ServerWindowItemsPacket : IPacket
    {
        //this.windowId = in.readUnsignedByte();
       //this.items = new ItemStack[in.readShort()];
       //for(int index = 0; index < this.items.length; index++) {
       //this.items[index] = NetUtil.readItem(in);
       //}
        public void Read(IMinecraftStreamReader stream)
        {
            
        }

        public void Write(IMinecraftStreamWriter stream)
        {
            
        }

        public ServerWindowItemsPacket() {}
    }

}
