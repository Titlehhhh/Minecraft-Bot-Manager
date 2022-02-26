using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.IO;


namespace ProtocolLib340.Packets.Server.Game.Entity
{

    
    public class ServerEntityEffectPacket : IPacket
    {
        //this.entityId = in.readVarInt();
       //this.effect = MagicValues.key(Effect.class, in.readByte());
       //this.amplifier = in.readByte();
       //this.duration = in.readVarInt();
       //
       //int flags = in.readByte();
       //this.ambient = (flags & 0x1) == 0x1;
       //this.showParticles = (flags & 0x2) == 0x2;
        public void Read(IMinecraftStreamReader stream)
        {
            
        }

        public void Write(IMinecraftStreamWriter stream)
        {
            
        }

        public ServerEntityEffectPacket() {}
    }

}
