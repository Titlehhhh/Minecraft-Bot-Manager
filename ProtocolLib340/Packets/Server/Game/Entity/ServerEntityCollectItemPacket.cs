using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.IO;


namespace ProtocolLib340.Packets.Server
{

    
    public class ServerEntityCollectItemPacket : IPacket
    {
        //this.collectedEntityId = in.readVarInt();
       //this.collectorEntityId = in.readVarInt();
       //this.itemCount = in.readVarInt();
        public void Read(IMinecraftStreamReader stream)
        {
            
        }

        public void Write(IMinecraftStreamWriter stream)
        {
            
        }

        public ServerEntityCollectItemPacket() {}
    }

}
