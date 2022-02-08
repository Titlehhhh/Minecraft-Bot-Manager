using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Protocol.Helpres;

namespace ProtocolLib340.Packets.Server.Game.Entity.Spawn
{

    [PacketMeta(0x02, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerSpawnGlobalEntityPacket : MinecraftPacket
    {
        //this.entityId = in.readVarInt();
       //this.type = MagicValues.key(GlobalEntityType.class, in.readByte());
       //this.x = in.readDouble();
       //this.y = in.readDouble();
       //this.z = in.readDouble();
        public override void Read(IMinecraftStreamReader input)
        {
            
        }
        public ServerSpawnGlobalEntityPacket() {}
    }

}
