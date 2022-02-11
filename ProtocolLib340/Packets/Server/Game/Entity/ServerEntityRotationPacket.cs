using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Server.Game.Entity
{

    [PacketInfo(0x28, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerEntityRotationPacket : IPacket
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
        public void Read(MinecraftStream stream)
        {
            
        }

        public void Write(MinecraftStream stream)
        {
            
        }

        public ServerEntityRotationPacket() {}
    }

}
