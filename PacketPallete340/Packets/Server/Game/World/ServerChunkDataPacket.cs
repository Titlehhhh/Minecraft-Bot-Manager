using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Protocol.Helpres;

namespace PacketPallete340.Packets.Server.Game.World
{

    [PacketMeta(0x20, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerChunkDataPacket : MinecraftPacket
    {
        //int x = in.readInt();
       //int z = in.readInt();
       //boolean fullChunk = in.readBoolean();
       //int chunkMask = in.readVarInt();
       //byte data[] = in.readBytes(in.readVarInt());
       //CompoundTag[] tileEntities = new CompoundTag[in.readVarInt()];
       //for(int i = 0; i < tileEntities.length; i++) {
       //tileEntities[i] = NetUtil.readNBT(in);
       //}
       //
       //this.column = NetUtil.readColumn(data, x, z, fullChunk, false, chunkMask, tileEntities);
        public override void Read(MinecraftStream output)
        {
            
        }
        public ServerChunkDataPacket() {}
    }

}
