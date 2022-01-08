using MinecraftLibrary.Data;
using MinecraftLibrary.Geometri;
using MinecraftLibrary.MinecraftProtocol.Data.Inventory;
using MinecraftProtocol.IO;
using MinecraftProtocol.Packets;
using System.Collections.Generic;

namespace MinecraftLibrary.MinecraftProtocol.Packets.Server.Game
{
    public class ServerMultiBlockChangePacket : ServerPacket
    {
        public List<Block> Blocks { get; private set; } = new List<Block>();
        public void Read(NetInput input, int version)
        {
            if (version >= MinecraftConstans. MC1162Version)
            {
                long chunkSection = input.ReadNextLong();
                int sectionX = (int)(chunkSection >> 42);
                int sectionY = (int)((chunkSection << 44) >> 44);
                int sectionZ = (int)((chunkSection << 22) >> 42);
                input.ReadNextBool(); // Useless boolean
                int blocksSize = input.ReadNextVarInt();
                for (int i = 0; i < blocksSize; i++)
                {
                    ulong block = (ulong)input.ReadNextVarLong();
                    int blockId = (int)(block >> 12);
                    int localX = (int)((block >> 8) & 0x0F);
                    int localZ = (int)((block >> 4) & 0x0F);
                    int localY = (int)(block & 0x0F);

                    
                    int blockX = (sectionX * 16) + localX;
                    int blockY = (sectionY * 16) + localY;
                    int blockZ = (sectionZ * 16) + localZ;
                    var l = new Location(blockX, blockY, blockZ);
                    Block b = new Block((ushort)blockId,l);
                    Blocks.Add(b);
                }
            }
            else
            {
                int chunkX = input.ReadNextInt();
                int chunkZ = input.ReadNextInt();
                int recordCount =input.ReadNextVarInt();

                for (int i = 0; i < recordCount; i++)
                {
                    short pos = input.ReadNextShort();
                    ushort blockIdMeta=(ushort)input.ReadNextVarInt();
                    int x = (chunkX >> 4) + (pos >> 12 & 15);
                    int y = pos & 255;
                    int z = (chunkZ << 4) + (pos >> 8 & 15);
                    Block block = new Block(blockIdMeta, new Location(x, y, z));
                    Blocks.Add(block);
                }
            }
        }
    }


}
