using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Server.Game.Window
{

    [PacketHeader(0x16, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerSetSlotPacket : IPacket
    {
        //this.windowId = in.readUnsignedByte();
       //this.slot = in.readShort();
       //this.item = NetUtil.readItem(in);
        public void Read(MinecraftStream stream)
        {
            
        }

        public void Write(MinecraftStream stream)
        {
            
        }

        public ServerSetSlotPacket() {}
    }

}
