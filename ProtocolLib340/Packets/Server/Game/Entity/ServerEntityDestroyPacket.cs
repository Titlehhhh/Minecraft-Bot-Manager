using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Server.Game.Entity
{

    [PacketInfo(0x32, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerEntityDestroyPacket : IPacket
    {
        //this.entityIds = new int[in.readVarInt()];
       //for(int index = 0; index < this.entityIds.length; index++) {
       //this.entityIds[index] = in.readVarInt();
       //}
        public void Read(MinecraftStream stream)
        {
            
        }

        public void Write(MinecraftStream stream)
        {
            
        }

        public ServerEntityDestroyPacket() {}
    }

}
