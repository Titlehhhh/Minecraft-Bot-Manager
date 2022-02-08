using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Protocol.Helpres;

namespace ProtocolLib340.Packets.Server.Game.Window
{

    [PacketMeta(0x14, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerWindowItemsPacket : MinecraftPacket
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
