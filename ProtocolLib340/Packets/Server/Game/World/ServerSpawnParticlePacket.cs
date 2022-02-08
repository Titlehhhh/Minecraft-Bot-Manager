using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Protocol.Helpres;

namespace ProtocolLib340.Packets.Server.Game.World
{

    [PacketMeta(0x22, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerSpawnParticlePacket : MinecraftPacket
    {
        //this.particle = MagicValues.key(Particle.class, in.readInt());
       //this.longDistance = in.readBoolean();
       //this.x = in.readFloat();
       //this.y = in.readFloat();
       //this.z = in.readFloat();
       //this.offsetX = in.readFloat();
       //this.offsetY = in.readFloat();
       //this.offsetZ = in.readFloat();
       //this.velocityOffset = in.readFloat();
       //this.amount = in.readInt();
       //this.data = new int[this.particle.getDataLength()];
       //for(int index = 0; index < this.data.length; index++) {
       //this.data[index] = in.readVarInt();
       //}
        public override void Read(IMinecraftStreamReader input)
        {
            
        }
        public ServerSpawnParticlePacket() {}
    }

}
