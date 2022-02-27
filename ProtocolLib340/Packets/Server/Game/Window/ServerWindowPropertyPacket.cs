using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.IO;


namespace ProtocolLib340.Packets.Server
{

    
    public class ServerWindowPropertyPacket : IPacket
    {
        //this.windowId = in.readUnsignedByte();
       //this.property = in.readShort();
       //this.value = in.readShort();
        public void Read(IMinecraftStreamReader stream)
        {
            
        }

        public void Write(IMinecraftStreamWriter stream)
        {
            
        }

        public ServerWindowPropertyPacket() {}
    }

}
