using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Protocol.Helpres;

namespace PacketPallete340.Packets.Server.Game.Entity
{

    [PacketMeta(0x3C, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerEntityMetadataPacket : MinecraftPacket
    {
        //this.entityId = in.readVarInt();
       //this.metadata = NetUtil.readEntityMetadata(in);
        public override void Read(MinecraftStream output)
        {
            
        }
        public ServerEntityMetadataPacket() {}
    }

}
