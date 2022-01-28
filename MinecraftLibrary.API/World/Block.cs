using MinecraftLibrary.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftLibrary.API.World
{
    public struct Block
    {
        private Point3_Int position;
        public Point3_Int Position => position;
        private int blockId;

        public int BlockID => blockId;
        private byte blockMeta;

        public byte BlockMeta => blockMeta;

        public Block(int type, byte metadata, Point3_Int pos) : this(pos)
        {
            this.blockId = type;
            this.blockMeta = metadata;
        }
        private Block(Point3_Int position) : this()
        {
            this.position = position;
        }

    }
}
