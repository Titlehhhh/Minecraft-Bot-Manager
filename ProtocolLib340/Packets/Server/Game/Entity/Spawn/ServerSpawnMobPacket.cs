using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Server.Game.Entity.Spawn
{

    [PacketHeader(0x03, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerSpawnMobPacket : IPacket
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
        public void Read(MinecraftStream stream)
        {
            
        }

        public void Write(MinecraftStream stream)
        {
            
        }

        public ServerSpawnMobPacket() {}
    }

}
