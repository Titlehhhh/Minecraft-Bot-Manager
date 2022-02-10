using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Server.Game.Entity.Spawn
{

    [PacketInfo(0x03, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerSpawnMobPacket : MinecraftPacket
    {
        //this.entityId = in.readVarInt();
       //this.uuid = in.readUUID();
       //this.type = MagicValues.key(MobType.class, in.readVarInt());
       //this.x = in.readDouble();
       //this.y = in.readDouble();
       //this.z = in.readDouble();
       //this.yaw = in.readByte() * 360 / 256f;
       //this.pitch = in.readByte() * 360 / 256f;
       //this.headYaw = in.readByte() * 360 / 256f;
       //this.motX = in.readShort() / 8000D;
       //this.motY = in.readShort() / 8000D;
       //this.motZ = in.readShort() / 8000D;
       //this.metadata = NetUtil.readEntityMetadata(in);
        public override void Read(IMinecraftStreamReader input)
        {
            
        }
        public ServerSpawnMobPacket() {}
    }

}
