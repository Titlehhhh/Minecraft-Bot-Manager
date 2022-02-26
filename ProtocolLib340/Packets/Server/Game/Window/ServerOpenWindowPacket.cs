using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.IO;


namespace ProtocolLib340.Packets.Server.Game.Window
{

    
    public class ServerOpenWindowPacket : IPacket
    {
        //this.windowId = in.readUnsignedByte();
       //this.type = MagicValues.key(WindowType.class, in.readString());
       //this.name = in.readString();
       //this.slots = in.readUnsignedByte();
       //if(this.type == WindowType.HORSE) {
       //this.ownerEntityId = in.readInt();
       //}
        public void Read(IMinecraftStreamReader stream)
        {
            
        }

        public void Write(IMinecraftStreamWriter stream)
        {
            
        }

        public ServerOpenWindowPacket() {}
    }

}
