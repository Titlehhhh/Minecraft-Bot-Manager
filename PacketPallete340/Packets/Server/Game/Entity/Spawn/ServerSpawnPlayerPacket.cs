using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Protocol.Helpres;

namespace PacketPallete340.Packets.Server.Game.Entity.Spawn
{

    [PacketMeta(0x05, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerSpawnPlayerPacket : MinecraftPacket
    {
        //this.entityId = in.readVarInt();
       //this.uuid = in.readUUID();
       //this.x = in.readDouble();
       //this.y = in.readDouble();
       //this.z = in.readDouble();
       //this.yaw = in.readByte() * 360 / 256f;
       //this.pitch = in.readByte() * 360 / 256f;
       //this.metadata = NetUtil.readEntityMetadata(in);
        public override void Read(MinecraftStream output)
        {
            
        }
        public ServerSpawnPlayerPacket() {}
    }

}
