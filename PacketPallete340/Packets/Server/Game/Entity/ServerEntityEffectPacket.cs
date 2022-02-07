using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Protocol.Helpres;

namespace PacketPallete340.Packets.Server.Game.Entity
{

    [PacketMeta(0x4F, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerEntityEffectPacket : MinecraftPacket
    {
        //this.entityId = in.readVarInt();
       //this.effect = MagicValues.key(Effect.class, in.readByte());
       //this.amplifier = in.readByte();
       //this.duration = in.readVarInt();
       //
       //int flags = in.readByte();
       //this.ambient = (flags & 0x1) == 0x1;
       //this.showParticles = (flags & 0x2) == 0x2;
        public override void Read(IMinecraftStreamReader input)
        {
            
        }
        public ServerEntityEffectPacket() {}
    }

}
