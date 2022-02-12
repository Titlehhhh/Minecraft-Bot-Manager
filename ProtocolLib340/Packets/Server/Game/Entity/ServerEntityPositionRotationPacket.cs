using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Server.Game.Entity
{

    [PacketHeader(0x27, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerEntityPositionRotationPacket : IPacket
    {
        //protected ServerEntityPositionRotationPacket() {
       //this.pos = true;
       //this.rot = true;
       //}
       //
       //public ServerEntityPositionRotationPacket(int entityId, double moveX, double moveY, double moveZ, float yaw, float pitch, boolean onGround) {
       //super(entityId, onGround);
       //this.pos = true;
       //this.rot = true;
       //this.moveX = moveX;
       //this.moveY = moveY;
       //this.moveZ = moveZ;
       //this.yaw = yaw;
       //this.pitch = pitch;
       //}
        public void Read(MinecraftStream stream)
        {
            
        }

        public void Write(MinecraftStream stream)
        {
            
        }

        public ServerEntityPositionRotationPacket() {}
    }

}
