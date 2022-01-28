using MinecraftLibrary.API.World;

using MinecraftLibrary.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftLibrary.Core.World
{
    public class ChunkColumn : IChunkColumn
    {        
        

        private int x;
        private int z;
        public int X => x;

        public int Z => z;
        IChunk[] chunks;

        public IChunk[] Chunks => chunks ?? (chunks = new Chunk[16]);
        public IChunk GetChunk(int y)
        {
            if (y > 0 && y <= 15)
                return Chunks[y];
            return new UnkownChunk();
        }

        public ChunkColumn(int x, int z)
        {
            chunks = new Chunk[16];           

            this.x = x;
            this.z = z;
        }
    }
    internal class UnkownChunk : IChunk
    {
        public int X => 0;

        public int Y => 0;

        public int Z => 0;

        public Point2_Int Position => new Point2_Int(0);
        Block[,,] blocks;
        public Block[,,] Blocks => blocks ?? (blocks = new Block[16, 16, 16]);
        private static Block Air = new Block(0, 0, new Point3_Int(0));
        public Block GetBlock(int x, int y, int z)
        {
            return Air;
        }

        public Block GetBlock(Point3_Int position)
        {
            return GetBlock(position.X, position.Y, position.Z);
        }

        public Block GetBlock(Point3 player)
        {
            return GetBlock(player.ChunkX, player.ChunkY, player.ChunkZ);
        }

        public void SetBlock(int x, int y, int z, Block block)
        {

        }

        public void SetBlock(Point3_Int position, Block block)
        {

        }
    }
}
