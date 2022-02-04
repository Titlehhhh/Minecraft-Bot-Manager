using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Protocol.Helpres;

namespace PacketPallete340.Packets.Server.Game.Entity
{

    [PacketMeta(0x32, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerEntityDestroyPacket : MinecraftPacket
    {
        //this.entityIds = new int[in.readVarInt()];
       //for(int index = 0; index < this.entityIds.length; index++) {
       //this.entityIds[index] = in.readVarInt();
       //}
        public override void Read(MinecraftStream output)
        {
            
        }
        public ServerEntityDestroyPacket() {}
    }

}
