using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Server.Game.Entity
{

    [PacketInfo(0x26, 340, PacketSide.Server, PacketCategory.Game)]
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
        public override void Read(IMinecraftStreamReader input)
        {
            
        }
        public ServerEntityPositionPacket() {}
    }

}
