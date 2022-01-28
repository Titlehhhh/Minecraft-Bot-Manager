using MinecraftLibrary.API.World;
using MinecraftLibrary.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftLibrary.API.World
{
    public interface IChunk
    {
        #region Свойства
        int X { get; }
        int Y { get; }
        int Z { get; }        
        Block[,,] Blocks { get; }
        #endregion

        #region Get/Set IBlock
        Block GetBlock(int x, int y, int z);
        Block GetBlock(Point3_Int position);        
        void SetBlock(int x, int y, int z, Block block);
        void SetBlock(Point3_Int position, Block block);
        #endregion

    }
}
