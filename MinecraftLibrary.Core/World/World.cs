using MinecraftLibrary.API.World;
using MinecraftLibrary.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftLibrary.Core.World
{
    
    public class World : IWorld
    {
        
        

        public World()
        {

        }
        private Dictionary<long, IChunkColumn> chunks = new Dictionary<long, IChunkColumn>();
        public Dictionary<long, IChunkColumn> ChunkColumns => chunks;

        public int Dimension { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public event EventHandler<BlockChangeEventArgs> ChangeBlock;
        public event EventHandler<ChunkColumnRecord> LoadChunkColumn;
        public event EventHandler<ChunkColumnRecord> UnLoadChunkColumn;

        public void Clear()
        {
            chunks = new Dictionary<long, IChunkColumn>();
        }

        public void Dispose()
        {
            Clear();
        }
        private static long TwoIntToLong(int val1,int val2)
        {
            long b = val2;
            b = (b << 32) | ((uint)val1);
            return b;
        }

        public IEnumerable<Block> FindBlock(Point3_Int start, double radius, int id)
        {
            return null;
        }

        public IEnumerable<Block> FindBlock(Point3_Int start, double radius, int id, byte meta = 0)
        {
            return null;
        }

        public Block GetBlock(Point3_Int position)
        {
            return GetBlock(position.X, position.Y, position.Z);
        }

        public Block GetBlock(int x, int y, int z)
        {
            return GetBlock(new Point3(x, y, z));
        }

        public Block GetBlock(Point3 player)
        {
            return GetChunkColumn(player).GetChunk(player.ChunkY).GetBlock(player.ChunkBlockX, player.ChunkBlockY, player.ChunkBlockZ);
        }

        public IChunk GetChunk(Point3_Int position)
        {
            return GetChunk(position.X, position.Y, position.Z);
        }

        public IChunk GetChunk(int x, int y, int z)
        {
            return GetChunk(new Point3(x, y, z));
        }

        public IChunk GetChunk(Point3 player)
        {
            return GetChunkColumn(player).GetChunk(player.ChunkY);
        }
        #region Get ChunkColumn
        public IChunkColumn GetChunkColumn(Point2_Int postition)
        {
            return GetChunkColumn(postition.X, postition.Z);
        }

        public IChunkColumn GetChunkColumn(int x, int z)
        {
            long key = TwoIntToLong(x, z);
            if (chunks.ContainsKey(key))
                return chunks[key];
            return new UnkownChunkColumn();
                    
        }

        public IChunkColumn GetChunkColumn(Point3 player)
        {
            return GetChunkColumn(player.ChunkX, player.ChunkZ);
        }
        #endregion

        public void SetBlock(Point3_Int position, Block block)
        {
            SetBlock(position.X, position.Y, position.Z, block);
        }

        public void SetBlock(int x, int y, int z, Block block)
        {
            int blockX = x & 15;
            int blockY = y & 15;
            int blockZ = z & 15;
            IChunk chunk = GetChunk(x, y, z);
            Block old = chunk.GetBlock(blockX, blockY, blockZ);
            chunk.SetBlock(blockX, blockY, blockZ,block);
            ChangeBlock?.Invoke(this, new BlockChangeEventArgs(new Point3_Int(x,y,z),old, block));
        }

        public void SetChunkColumn(Point2_Int position, IChunkColumn column)
        {
            SetChunkColumn(position.X, position.Z, column);
        }

        public void SetChunkColumn(int x, int z, IChunkColumn column)
        {
            long key = TwoIntToLong(x, z);
            chunks[key] = column;
            LoadChunkColumn?.Invoke(this, new ChunkColumnRecord(x, z));
        }

        public void UnLoadChunk(int x, int z)
        {
            long key = TwoIntToLong(x, z);
            if (chunks.Remove(key))
                UnLoadChunkColumn?.Invoke(this, new ChunkColumnRecord(x, z));

        }
    }
    internal class UnkownChunkColumn : IChunkColumn
    {
        public int X => 0;
        public int Z => 0;
        private IChunk[] chunks;
        public IChunk[] Chunks => chunks ?? (chunks = new IChunk[16]);

        public IChunk GetChunk(int y)
        {
            return new UnkownChunk();
        }
    }
}
