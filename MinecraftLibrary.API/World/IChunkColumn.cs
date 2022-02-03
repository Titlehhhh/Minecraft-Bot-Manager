using MinecraftLibrary.API.World;
using MinecraftLibrary.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftLibrary.API.World
{
    public interface IChunkColumn
    {
        int X { get; }
        int Z { get; }
        int SizeY { get; }
        IChunk[] Chunks { get; }
        #region Get/Set IChunk        
        IChunk GetChunk(int y);        
        #endregion
        

    }
}
