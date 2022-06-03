using McProtoNet.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftBotManager.Domain
{
    public struct Block
    {
        public Point3_Int Position { get; private set; }

        public string Id { get; private set; }

        public Block(Point3_Int position, string id)
        {
            Position = position;
            Id = id;
        }
    }

    public class Chunk
    {


        public Block[,,] Blocks { get; private set; }

        public Chunk(Block[,,] blocks)
        {
            Blocks = blocks;
        }
    }


    public class ChunkColumn
    {
        public Point2_Int Position{ get; private set; }

        public Chunk[] Chunks { get; private set; }

        public ChunkColumn(Chunk[] chunks)
        {
            Chunks = chunks;
        }
    }

    public interface IWorld
    {
        
    }
}
