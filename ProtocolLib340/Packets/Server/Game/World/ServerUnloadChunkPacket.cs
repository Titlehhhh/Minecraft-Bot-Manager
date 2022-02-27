using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.IO;


namespace ProtocolLib340.Packets.Server
{

    
    public class ServerUnloadChunkPacket : IPacket
    {
        //this.x = in.readInt();
       //this.z = in.readInt();
        public void Read(IMinecraftStreamReader stream)
        {
            
        }

        public void Write(IMinecraftStreamWriter stream)
        {
            
        }

        public ServerUnloadChunkPacket() {}
    }

}
