using MinecraftLibrary.Data;
using MinecraftLibrary.MinecraftProtocol.Data.Inventory;
using MinecraftProtocol.IO;
using MinecraftProtocol.Packets;
using System;

namespace MinecraftLibrary.MinecraftProtocol.Packets.Server.Game
{
    public class ServerChunkDataPacket : ServerPacket
    {
        public int ColumnX { get; private set; }
        public int ColumnZ { get; private set; }

        public ChunkColumn Column { get; private set; }
        public void Read(NetInput input, int version)
        {
            Column = new ChunkColumn();

            ColumnX = input.ReadNextInt();
            ColumnZ = input.ReadNextInt();

            Column.ChunkX = ColumnX;
            Column.ChunkZ = ColumnZ;

            bool chunksContinuous = input.ReadNextBool();
            if (version >= MinecraftConstans.MC116Version && version <= MinecraftConstans.MC1161Version)
                input.ReadNextBool(); // Ignore old data - 1.16 to 1.16.1 only
            ushort chunkMask = (ushort)input.ReadNextVarInt();

            if (version >= MinecraftConstans.MC114Version)
                input.ReadNextNbt();  // Heightmaps - 1.14 and above
            int biomesLength = 0;
            if (version >= MinecraftConstans.MC1162Version)
                if (chunksContinuous)
                    biomesLength = input.ReadNextVarInt(); // Biomes length - 1.16.2 and above
            if (version >= MinecraftConstans.MC115Version && chunksContinuous)
            {
                if (version >= MinecraftConstans.MC1162Version)
                {
                    for (int i = 0; i < biomesLength; i++)
                    {
                        // Biomes - 1.16.2 and above
                        // Don't use ReadNextVarInt because it cost too much time
                        input.ReadNextVarInt();
                    }
                }
                else input.ReadData(1024 * 4); // Biomes - 1.15 and above
            }
            int dataSize = input.ReadNextVarInt();




            // 1.9 and above chunk format
            // Unloading chunks is handled by a separate packet
            for (int chunkY = 0; chunkY < ChunkColumn.ColumnSize; chunkY++)
            {
                if ((chunkMask & (1 << chunkY)) != 0)
                {
                    // 1.14 and above Non-air block count inside chunk section, for lighting purposes
                    if (version >= MinecraftConstans.MC114Version)
                        input.ReadNextShort();

                    byte bitsPerBlock = input.ReadNextByte();
                    bool usePalette = (bitsPerBlock <= 8);

                    // Vanilla Minecraft will use at least 4 bits per block
                    if (bitsPerBlock < 4)
                        bitsPerBlock = 4;

                    // MC 1.9 to 1.12 will set palette length field to 0 when palette
                    // is not used, MC 1.13+ does not send the field at all in this case
                    int paletteLength = 0; // Assume zero when length is absent
                    if (usePalette || version < MinecraftConstans.MC113Version)
                        paletteLength = input.ReadNextVarInt();

                    int[] palette = new int[paletteLength];
                    for (int i = 0; i < paletteLength; i++)
                    {
                        palette[i] = input.ReadNextVarInt();
                    }

                    // Bit mask covering bitsPerBlock bits
                    // EG, if bitsPerBlock = 5, valueMask = 00011111 in binary
                    uint valueMask = (uint)((1 << bitsPerBlock) - 1);

                    // Block IDs are packed in the array of 64-bits integers
                    ulong[] dataArray = input.ReadNextULongArray();

                    Chunk chunk = new Chunk();

                    if (dataArray.Length > 0)
                    {
                        int longIndex = 0;
                        int startOffset = 0 - bitsPerBlock;

                        for (int blockY = 0; blockY < Chunk.SizeY; blockY++)
                        {
                            for (int blockZ = 0; blockZ < Chunk.SizeZ; blockZ++)
                            {
                                for (int blockX = 0; blockX < Chunk.SizeX; blockX++)
                                {
                                    // NOTICE: In the future a single ushort may not store the entire block id;
                                    // the Block class may need to change if block state IDs go beyond 65535
                                    ushort blockId;

                                    // Calculate location of next block ID inside the array of Longs
                                    startOffset += bitsPerBlock;
                                    bool overlap = false;

                                    if ((startOffset + bitsPerBlock) > 64)
                                    {
                                        if (version >= MinecraftConstans.MC116Version)
                                        {
                                            // In MC 1.16+, padding is applied to prevent overlapping between Longs:
                                            // [      LONG INTEGER      ][      LONG INTEGER      ]
                                            // [Block][Block][Block]XXXXX[Block][Block][Block]XXXXX

                                            // When overlapping, move forward to the beginning of the next Long
                                            startOffset = 0;
                                            longIndex++;
                                        }
                                        else
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
                                            int blockNumber = (blockY * Chunk.SizeZ + blockZ) * Chunk.SizeX + blockX;
                                            throw new IndexOutOfRangeException(String.Format("Block ID {0} is outside Palette range 0-{1}! (bitsPerBlock: {2}, blockNumber: {3})",
                                                blockId,
                                                paletteLength - 1,
                                                bitsPerBlock,
                                                blockNumber));
                                        }

                                        blockId = (ushort)palette[blockId];
                                    }

                                    // We have our block, save the block into the chunk
                                    chunk[blockX, blockY, blockZ] = new Block(blockId, new Point3D_I32(blockX, blockY, blockZ));
                                }
                            }
                        }
                    }

                    //We have our chunk, save the chunk into the world



                    Column[chunkY] = chunk;
                    ////Pre-1.14 Lighting data
                    //if (protocolversion < Protocol18Handler.MC114Version)
                    //{
                    //    //Skip block light
                    //    dataTypes.ReadData((Chunk.SizeX * Chunk.SizeY * Chunk.SizeZ) / 2, cache);

                    //    //Skip sky light
                    //    if (currentDimension == 0)
                    //        // Sky light is not sent in the nether or the end
                    //        dataTypes.ReadData((Chunk.SizeX * Chunk.SizeY * Chunk.SizeZ) / 2, cache);
                    //}
                }
            }

        }
    }


}
