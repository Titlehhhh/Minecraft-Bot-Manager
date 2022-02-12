using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Server.Game.Entity
{

    [PacketHeader(0x26, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerEntityPositionPacket : IPacket
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
        public void Read(MinecraftStream stream)
        {
            
        }

        public void Write(MinecraftStream stream)
        {
            
        }

        public ServerEntityPositionPacket() {}
    }

}
