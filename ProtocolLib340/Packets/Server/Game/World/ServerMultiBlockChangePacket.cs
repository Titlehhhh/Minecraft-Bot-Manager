using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Server.Game.World
{

    [PacketInfo(0x10, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerMultiBlockChangePacket : MinecraftPacket
    {
        //int chunkX = in.readInt();
       //int chunkZ = in.readInt();
       //this.records = new BlockChangeRecord[in.readVarInt()];
       //for(int index = 0; index < this.records.length; index++) {
       //short pos = in.readShort();
       //BlockState block = NetUtil.readBlockState(in);
       //int x = (chunkX << 4) + (pos >> 12 & 15);
       //int y = pos & 255;
       //int z = (chunkZ << 4) + (pos >> 8 & 15);
       //this.records[index] = new BlockChangeRecord(new Position(x, y, z), block);
       //}
        public override void Read(IMinecraftStreamReader input)
        {
            
        }
        public ServerMultiBlockChangePacket() {}
    }

}
