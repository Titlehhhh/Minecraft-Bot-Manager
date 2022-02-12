using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Server.Game.Entity.Spawn
{

    [PacketHeader(0x02, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerSpawnGlobalEntityPacket : IPacket
    {
        //this.entityId = in.readVarInt();
       //this.type = MagicValues.key(GlobalEntityType.class, in.readByte());
       //this.x = in.readDouble();
       //this.y = in.readDouble();
       //this.z = in.readDouble();
        public void Read(MinecraftStream stream)
        {
            
        }

        public void Write(MinecraftStream stream)
        {
            
        }

        public ServerSpawnGlobalEntityPacket() {}
    }

}
