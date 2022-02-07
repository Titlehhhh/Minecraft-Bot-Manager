using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Protocol.Helpres;

namespace PacketPallete340.Packets.Server.Game.Entity
{

    [PacketMeta(0x28, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerEntityRotationPacket : MinecraftPacket
    {
        //protected ServerEntityRotationPacket() {
       //this.rot = true;
       //}
       //
       //public ServerEntityRotationPacket(int entityId, float yaw, float pitch, boolean onGround) {
       //super(entityId, onGround);
       //this.rot = true;
       //this.yaw = yaw;
       //this.pitch = pitch;
       //}
        public override void Read(IMinecraftStreamReader input)
        {
            
        }
        public ServerEntityRotationPacket() {}
    }

}
