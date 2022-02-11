using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Server.Game.Entity
{

    [PacketInfo(0x4F, 340, PacketSide.Server, PacketCategory.Game)]
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
        public void Read(MinecraftStream stream)
        {
            
        }

        public void Write(MinecraftStream stream)
        {
            
        }

        public ServerEntityEffectPacket() {}
    }

}
