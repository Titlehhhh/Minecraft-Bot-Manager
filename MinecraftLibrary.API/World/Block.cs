using MinecraftLibrary.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftLibrary.API.World
{
    public interface IBlock
    {
        int ID { get; }
        Point3_Int Position { get; }

    }
}
