using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Protocol.Helpres;

namespace ProtocolLib340.Packets.Server.Game.Entity
{

    [PacketMeta(0x25, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerEntityMovementPacket : MinecraftPacket
    {
        //this.entityId = in.readVarInt();
       //if(this.pos) {
       //this.moveX = in.readShort() / 4096D;
       //this.moveY = in.readShort() / 4096D;
       //this.moveZ = in.readShort() / 4096D;
       //}
       //
       //if(this.rot) {
       //this.yaw = in.readByte() * 360 / 256f;
       //this.pitch = in.readByte() * 360 / 256f;
       //}
       //
       //if(this.pos || this.rot) {
       //this.onGround = in.readBoolean();
       //}
        public override void Read(IMinecraftStreamReader input)
        {
            
        }
        public ServerEntityMovementPacket() {}
    }

}
