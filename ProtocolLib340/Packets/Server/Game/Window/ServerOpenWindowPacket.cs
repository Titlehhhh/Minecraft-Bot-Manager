using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Server.Game.Window
{

    [PacketInfo(0x13, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerOpenWindowPacket : IPacket
    {
        //this.windowId = in.readUnsignedByte();
       //this.type = MagicValues.key(WindowType.class, in.readString());
       //this.name = in.readString();
       //this.slots = in.readUnsignedByte();
       //if(this.type == WindowType.HORSE) {
       //this.ownerEntityId = in.readInt();
       //}
        public void Read(MinecraftStream stream)
        {
            
        }

        public void Write(MinecraftStream stream)
        {
            
        }

        public ServerOpenWindowPacket() {}
    }

}
