using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.IO;


namespace ProtocolLib340.Packets.Server.Game.Entity
{

    
    public class ServerEntityDestroyPacket : IPacket
    {
        //this.entityIds = new int[in.readVarInt()];
       //for(int index = 0; index < this.entityIds.length; index++) {
       //this.entityIds[index] = in.readVarInt();
       //}
        public void Read(IMinecraftStreamReader stream)
        {
            
        }

        public void Write(IMinecraftStreamWriter stream)
        {
            
        }

        public ServerEntityDestroyPacket() {}
    }

}
