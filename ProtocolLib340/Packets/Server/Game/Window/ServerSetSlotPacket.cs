using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.IO;


namespace ProtocolLib340.Packets.Server.Game.Window
{

    
    public class ServerSetSlotPacket : IPacket
    {
        //this.windowId = in.readUnsignedByte();
       //this.slot = in.readShort();
       //this.item = NetUtil.readItem(in);
        public void Read(IMinecraftStreamReader stream)
        {
            
        }

        public void Write(IMinecraftStreamWriter stream)
        {
            
        }

        public ServerSetSlotPacket() {}
    }

}
