using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Protocol.Helpres;
using MinecraftLibrary.API.World;

namespace PacketPallete340.Packets.Server.Game.World
{

    [PacketMeta(0x20, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerChunkDataPacket : MinecraftPacket
    {
        public IChunkColumn Column { get; set; }
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
            int x = output.ReadNextInt();
            int z = output.ReadNextInt();
            bool fullChunk = output.ReadNextBool();
            byte[] data = output.ReadNextByteArray();
            
        }
        public ServerChunkDataPacket() {}
    }

}
