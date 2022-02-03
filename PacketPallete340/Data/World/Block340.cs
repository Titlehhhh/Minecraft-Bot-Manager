using MinecraftLibrary.API.World;
using MinecraftLibrary.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PacketPallete340.Data.World
{    
    public struct Block340 : IBlock
    {
        private Point3_Int position;
        public Point3_Int Position => position;
        private int blockId;
        private byte blockMeta;

        public byte BlockMeta => blockMeta;

        public int ID => blockId;

        public Block340(int type, byte metadata, Point3_Int pos) : this(pos)
        {
            this.blockId = type;
            this.blockMeta = metadata;
        }
        private Block340(Point3_Int position) : this()
        {
            this.position = position;
        }

    }
}
