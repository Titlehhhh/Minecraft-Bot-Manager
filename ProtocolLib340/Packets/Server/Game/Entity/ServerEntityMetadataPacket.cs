using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Server.Game.Entity
{

    [PacketInfo(0x3C, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerEntityMetadataPacket : MinecraftPacket
    {
        //this.entityId = in.readVarInt();
       //this.metadata = NetUtil.readEntityMetadata(in);
        public override void Read(IMinecraftStreamReader input)
        {
            
        }
        public ServerEntityMetadataPacket() {}
    }

}
