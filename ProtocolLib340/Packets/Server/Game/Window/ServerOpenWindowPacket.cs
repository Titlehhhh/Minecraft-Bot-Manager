using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Server.Game.Window
{

    [PacketInfo(0x13, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerOpenWindowPacket : MinecraftPacket
    {
        //this.windowId = in.readUnsignedByte();
       //this.type = MagicValues.key(WindowType.class, in.readString());
       //this.name = in.readString();
       //this.slots = in.readUnsignedByte();
       //if(this.type == WindowType.HORSE) {
       //this.ownerEntityId = in.readInt();
       //}
        public override void Read(IMinecraftStreamReader input)
        {
            
        }
        public ServerOpenWindowPacket() {}
    }

}
