using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Server.Game.Entity
{

    [PacketInfo(0x4C, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerEntityTeleportPacket : MinecraftPacket
    {
        //this.entityId = in.readVarInt();
       //this.x = in.readDouble();
       //this.y = in.readDouble();
       //this.z = in.readDouble();
       //this.yaw = in.readByte() * 360 / 256f;
       //this.pitch = in.readByte() * 360 / 256f;
       //this.onGround = in.readBoolean();
        public override void Read(IMinecraftStreamReader input)
        {
            
        }
        public ServerEntityTeleportPacket() {}
    }

}
