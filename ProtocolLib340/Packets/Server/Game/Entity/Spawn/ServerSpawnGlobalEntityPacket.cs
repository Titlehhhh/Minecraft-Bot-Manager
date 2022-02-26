using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.IO;


namespace ProtocolLib340.Packets.Server.Game.Entity.Spawn
{

    
    public class ServerSpawnGlobalEntityPacket : IPacket
    {
        //this.entityId = in.readVarInt();
       //this.type = MagicValues.key(GlobalEntityType.class, in.readByte());
       //this.x = in.readDouble();
       //this.y = in.readDouble();
       //this.z = in.readDouble();
        public void Read(IMinecraftStreamReader stream)
        {
            
        }

        public void Write(IMinecraftStreamWriter stream)
        {
            
        }

        public ServerSpawnGlobalEntityPacket() {}
    }

}
