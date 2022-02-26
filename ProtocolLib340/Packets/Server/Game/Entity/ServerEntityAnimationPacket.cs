using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.IO;


namespace ProtocolLib340.Packets.Server.Game.Entity
{

    
    public class ServerEntityAnimationPacket : IPacket
    {
        //this.entityId = in.readVarInt();
       //this.animation = MagicValues.key(Animation.class, in.readUnsignedByte());
        public void Read(IMinecraftStreamReader stream)
        {
            
        }

        public void Write(IMinecraftStreamWriter stream)
        {
            
        }

        public ServerEntityAnimationPacket() {}
    }

}
