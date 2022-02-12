using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Server.Game.Entity.Spawn
{

    [PacketHeader(0x01, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerSpawnExpOrbPacket : IPacket
    {
        //this.entityId = in.readVarInt();
       //this.x = in.readDouble();
       //this.y = in.readDouble();
       //this.z = in.readDouble();
       //this.exp = in.readShort();
        public void Read(MinecraftStream stream)
        {
            
        }

        public void Write(MinecraftStream stream)
        {
            
        }

        public ServerSpawnExpOrbPacket() {}
    }

}
