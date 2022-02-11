using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Server.Game.Entity.Spawn
{

    [PacketInfo(0x05, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerSpawnPlayerPacket : IPacket
    {
        //this.entityId = in.readVarInt();
       //this.uuid = in.readUUID();
       //this.x = in.readDouble();
       //this.y = in.readDouble();
       //this.z = in.readDouble();
       //this.yaw = in.readByte() * 360 / 256f;
       //this.pitch = in.readByte() * 360 / 256f;
       //this.metadata = NetUtil.readEntityMetadata(in);
        public override void Read(IMinecraftStreamReader input)
        {
            
        }
        public ServerSpawnPlayerPacket() {}
    }

}
