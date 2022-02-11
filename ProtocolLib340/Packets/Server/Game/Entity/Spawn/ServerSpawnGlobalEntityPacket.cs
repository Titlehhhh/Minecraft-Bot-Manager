using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Server.Game.Entity.Spawn
{

    [PacketInfo(0x02, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerSpawnGlobalEntityPacket : IPacket
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
