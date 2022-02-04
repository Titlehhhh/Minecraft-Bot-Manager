using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Protocol.Helpres;

namespace PacketPallete340.Packets.Server.Game.Entity
{

    [PacketMeta(0x26, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerEntityPositionPacket : MinecraftPacket
    {
        //protected ServerEntityPositionPacket() {
       //this.pos = true;
       //}
       //
       //public ServerEntityPositionPacket(int entityId, double moveX, double moveY, double moveZ, boolean onGround) {
       //super(entityId, onGround);
       //this.pos = true;
       //this.moveX = moveX;
       //this.moveY = moveY;
       //this.moveZ = moveZ;
       //}
        public override void Read(MinecraftStream output)
        {
            
        }
        public ServerEntityPositionPacket() {}
    }

}
