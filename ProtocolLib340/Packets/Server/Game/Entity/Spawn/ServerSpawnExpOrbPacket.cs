using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.IO;


namespace ProtocolLib340.Packets.Server.Game.Entity.Spawn
{

    
    public class ServerSpawnExpOrbPacket : IPacket
    {
        //this.entityId = in.readVarInt();
       //this.x = in.readDouble();
       //this.y = in.readDouble();
       //this.z = in.readDouble();
       //this.exp = in.readShort();
        public void Read(IMinecraftStreamReader stream)
        {
            
        }

        public void Write(IMinecraftStreamWriter stream)
        {
            
        }

        public ServerSpawnExpOrbPacket() {}
    }

}
