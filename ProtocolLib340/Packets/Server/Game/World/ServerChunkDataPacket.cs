using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;
using MinecraftLibrary.API.World;
using MinecraftLibrary.API.World.Implements;
using MinecraftLibrary.Geometry;
using ProtocolLib340.Data.World;

namespace ProtocolLib340.Packets.Server.Game.World
{

    [PacketInfo(0x20, 340, PacketSide.Server, PacketCategory.Game)]
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
        public override void Read(IMinecraftStreamReader input)
        {
            int x = input.ReadNextInt();
            int z = input.ReadNextInt();
            bool chunksContinuous = input.ReadNextBool();
            ushort chunkMask = (ushort)input.ReadNextVarInt();
            ChunkColumn column = new ChunkColumn(x, z);
            for(int chunkY = 0;chunkY< column.SizeY; chunkY++)
            {
                if((chunkMask & (1 << chunkY)) != 0)
                {
                    byte bitsPerBlock = input.ReadNextByte();
                    bool usePalette = (bitsPerBlock <= 8);
                    if (bitsPerBlock < 4)
                        bitsPerBlock = 4;
                    int paletteLength = 0; // Assume zero when length is absent
                    if (usePalette)
                        paletteLength = input.ReadNextVarInt();

                    int[] palette = new int[paletteLength];
                    for (int i = 0; i < paletteLength; i++)
                    {
                        palette[i] = input.ReadNextVarInt();
                    }

                    uint valueMask = (uint)((1 << bitsPerBlock) - 1);

                    // Block IDs are packed in the array of 64-bits integers
                    ulong[] dataArray = input.ReadNextULongArray();

                    Chunk chunk = new Chunk();

                    if (dataArray.Length > 0)
                    {
                        int longIndex = 0;
                        int startOffset = 0 - bitsPerBlock;

                        for (int blockY = 0; blockY < chunk.SizeY; blockY++)
                        {
                            for (int blockZ = 0; blockZ < chunk.SizeZ; blockZ++)
                            {
                                for (int blockX = 0; blockX < chunk.SizeX; blockX++)
                                {
                                    // NOTICE: In the future a single ushort may not store the entire block id;
                                    // the Block class may need to change if block state IDs go beyond 65535
                                    ushort blockId;

                                    // Calculate location of next block ID inside the array of Longs
                                    startOffset += bitsPerBlock;
                                    bool overlap = false;

                                    if ((startOffset + bitsPerBlock) > 64)
                                    {
                                       
                                            // In MC 1.15 and lower, block IDs can overlap between Longs:
                                            // [      LONG INTEGER      ][      LONG INTEGER      ]
                                            // [Block][Block][Block][Blo  ck][Block][Block][Block][

                                            // Detect when we reached the next Long or switch to overlap mode
                                            if (startOffset >= 64)
                                            {
                                                startOffset -= 64;
                                                longIndex++;
                                            }
                                            else overlap = true;
                                        
                                    }

                                    // Extract Block ID
                                    if (overlap)
                                    {
                                        int endOffset = 64 - startOffset;
                                        blockId = (ushort)((dataArray[longIndex] >> startOffset | dataArray[longIndex + 1] << endOffset) & valueMask);
                                    }
                                    else
                                    {
                                        blockId = (ushort)((dataArray[longIndex] >> startOffset) & valueMask);
                                    }

                                    // Map small IDs to actual larger block IDs
                                    if (usePalette)
                                    {
                                        if (paletteLength <= blockId)
                                        {
                                            int blockNumber = (blockY * chunk.SizeZ + blockZ) * chunk.SizeX + blockX;
                                            throw new IndexOutOfRangeException(String.Format("Block ID {0} is outside Palette range 0-{1}! (bitsPerBlock: {2}, blockNumber: {3})",
                                                blockId,
                                                paletteLength - 1,
                                                bitsPerBlock,
                                                blockNumber));
                                        }

                                        blockId = (ushort)palette[blockId];
                                    }
                                    Point3_Int point = new Point3_Int(blockX, blockY, blockZ);
                                    // We have our block, save the block into the chunk
                                    chunk.SetBlock(point, new Block340(blockId, point));
                                }
                            }
                        }
                    }


                }
            }

            Column = column;
        }

        public ServerChunkDataPacket(IChunkColumn column)
        {
            Column = column;
        }

        public ServerChunkDataPacket() {}
    }

}
