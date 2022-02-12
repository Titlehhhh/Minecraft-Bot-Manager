using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Server.Game.Entity
{

    [PacketHeader(0x3C, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerEntityMetadataPacket : IPacket
    {
        //this.entityId = in.readVarInt();
       //this.metadata = NetUtil.readEntityMetadata(in);
        public void Read(MinecraftStream stream)
        {
            
        }

        public void Write(MinecraftStream stream)
        {
            
        }

        public ServerEntityMetadataPacket() {}
    }

}
