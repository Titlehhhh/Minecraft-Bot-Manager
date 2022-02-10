using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Server.Game.Window
{

    [PacketInfo(0x16, 340, PacketSide.Server, PacketCategory.Game)]
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
