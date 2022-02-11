using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Server.Game.Window
{

    [PacketInfo(0x14, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerWindowItemsPacket : IPacket
    {
        //this.windowId = in.readUnsignedByte();
       //this.items = new ItemStack[in.readShort()];
       //for(int index = 0; index < this.items.length; index++) {
       //this.items[index] = NetUtil.readItem(in);
       //}
        public override void Read(IMinecraftStreamReader input)
        {
            
        }
        public ServerWindowItemsPacket() {}
    }

}
