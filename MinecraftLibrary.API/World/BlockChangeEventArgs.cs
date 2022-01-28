using MinecraftLibrary.API;
using MinecraftLibrary.API.World;
using MinecraftLibrary.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftLibrary.API.World
{
    public class BlockChangeEventArgs : EventArgs
    {
        public BlockChangeEventArgs(Point3_Int pos, Block oldBlock, Block newBlock)
        {
            Position = pos;
            OldBlock = oldBlock;
            NewBlock = newBlock;
        }

        public Point3_Int Position { get; private set; }
        public Block OldBlock { get; private set; }
        public Block NewBlock { get; private set; }
    }
}
