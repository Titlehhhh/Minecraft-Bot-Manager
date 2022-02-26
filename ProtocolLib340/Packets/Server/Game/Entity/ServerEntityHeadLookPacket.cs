using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.IO;


namespace ProtocolLib340.Packets.Server.Game.Entity
{

    
    public class ServerEntityHeadLookPacket : IPacket
    {
        //this.entityId = in.readVarInt();
       //this.headYaw = in.readByte() * 360 / 256f;
        public void Read(IMinecraftStreamReader stream)
        {
            
        }

        public void Write(IMinecraftStreamWriter stream)
        {
            
        }

        public ServerEntityHeadLookPacket() {}
    }

}
