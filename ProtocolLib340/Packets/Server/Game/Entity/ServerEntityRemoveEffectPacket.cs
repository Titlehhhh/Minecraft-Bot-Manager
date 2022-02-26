using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.IO;


namespace ProtocolLib340.Packets.Server.Game.Entity
{

    
    public class ServerEntityRemoveEffectPacket : IPacket
    {
        //this.entityId = in.readVarInt();
       //this.effect = MagicValues.key(Effect.class, in.readUnsignedByte());
        public void Read(IMinecraftStreamReader stream)
        {
            
        }

        public void Write(IMinecraftStreamWriter stream)
        {
            
        }

        public ServerEntityRemoveEffectPacket() {}
    }

}
