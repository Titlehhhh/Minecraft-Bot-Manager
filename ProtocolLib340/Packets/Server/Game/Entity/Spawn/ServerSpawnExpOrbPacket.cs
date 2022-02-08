using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Protocol.Helpres;

namespace ProtocolLib340.Packets.Server.Game.Entity.Spawn
{

    [PacketMeta(0x01, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerSpawnExpOrbPacket : MinecraftPacket
    {
        //this.entityId = in.readVarInt();
       //this.x = in.readDouble();
       //this.y = in.readDouble();
       //this.z = in.readDouble();
       //this.exp = in.readShort();
        public override void Read(IMinecraftStreamReader input)
        {
            
        }
        public ServerSpawnExpOrbPacket() {}
    }

}
