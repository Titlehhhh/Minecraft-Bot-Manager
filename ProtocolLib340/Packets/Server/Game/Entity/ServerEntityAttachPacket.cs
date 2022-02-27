using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.IO;


namespace ProtocolLib340.Packets.Server
{

    
    public class ServerEntityAttachPacket : IPacket
    {
        //this.entityId = in.readInt();
       //this.attachedToId = in.readInt();
        public void Read(IMinecraftStreamReader stream)
        {
            
        }

        public void Write(IMinecraftStreamWriter stream)
        {
            
        }

        public ServerEntityAttachPacket() {}
    }

}
