using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.IO;


namespace ProtocolLib340.Packets.Server
{

    
    public class ServerEntityMetadataPacket : IPacket
    {
        //this.entityId = in.readVarInt();
       //this.metadata = NetUtil.readEntityMetadata(in);
        public void Read(IMinecraftStreamReader stream)
        {
            
        }

        public void Write(IMinecraftStreamWriter stream)
        {
            
        }

        public ServerEntityMetadataPacket() {}
    }

}
