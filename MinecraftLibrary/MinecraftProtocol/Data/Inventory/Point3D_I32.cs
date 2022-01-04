using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftLibrary.MinecraftProtocol.Data.Inventory
{
    public struct Point3D_I32
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
        public Point3D_I32(int value)
        {
            X = Y = Z = value;
        }

        public Point3D_I32(int x, int y, int z) : this(x)
        {
            Y = y;
            Z = z;
        }
    }
}
