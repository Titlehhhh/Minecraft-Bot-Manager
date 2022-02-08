using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Protocol.Helpres;

namespace ProtocolLib340.Packets.Server.Game.Window
{

    [PacketMeta(0x16, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerSetSlotPacket : MinecraftPacket
    {
        //this.windowId = in.readUnsignedByte();
       //this.slot = in.readShort();
       //this.item = NetUtil.readItem(in);
        public override void Read(IMinecraftStreamReader input)
        {
            
        }
        public ServerSetSlotPacket() {}
    }

}
