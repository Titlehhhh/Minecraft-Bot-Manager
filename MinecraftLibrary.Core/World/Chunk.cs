using MinecraftLibrary.API.World;

using MinecraftLibrary.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftLibrary.Core.World
{
    public class Chunk : IChunk
    {
        private int x;
        private int y;
        private int z;

        public int X => x;

        public int Y => y;

        public int Z => z;
        private Block[,,] blocks;

        public Block[,,] Blocks => blocks;

        private static Block UnkownBlock = new Block(0, 0, new Point3_Int(0));
        public Block GetBlock(int x, int y, int z)
        {
            if (IsValidPos(x) && IsValidPos(y) && IsValidPos(z))
                return Blocks[x, y, z];
            return UnkownBlock;
        }
        private static bool IsValidPos(int value)
        {
            return value >= 0 && value <= 15;
        }

        public Block GetBlock(Point3_Int position)
        {
            return GetBlock(position.X, position.Y, position.Z);
        }

        public void SetBlock(int x, int y, int z, Block block)
        {
            if (IsValidPos(x) && IsValidPos(y) && IsValidPos(z))
                Blocks[x, y, z] = block;
        }

        public void SetBlock(Point3_Int position, Block block)
        {
            SetBlock(position.X, position.Y, position.Z, block);
        }

        public Chunk(int x, int y, int z)
        {            
            this.x = x;
            this.y = y;
            this.z = z;
        }

    }
}
