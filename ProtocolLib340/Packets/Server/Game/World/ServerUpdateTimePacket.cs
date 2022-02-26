using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.IO;


namespace ProtocolLib340.Packets.Server.Game.World
{

    
    public class ServerUpdateTimePacket : IPacket
    {
        //this.age = in.readLong();
       //this.time = in.readLong();
        public void Read(IMinecraftStreamReader stream)
        {
            
        }

        public void Write(IMinecraftStreamWriter stream)
        {
            
        }

        public ServerUpdateTimePacket() {}
    }

}
