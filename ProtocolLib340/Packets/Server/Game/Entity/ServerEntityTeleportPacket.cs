using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Protocol.Helpres;

namespace ProtocolLib340.Packets.Server.Game.Entity
{

    [PacketMeta(0x4C, 340, PacketSide.Server, PacketCategory.Game)]
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
