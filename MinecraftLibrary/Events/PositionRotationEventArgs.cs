using MinecraftLibrary.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftLibrary
{
    public class PositionRotationEventArgs
    {
        public Point3 Position { get; private set; }
        public Rotation Rotation { get; private set; }

        public bool OnGround { get; private set; }

        public PositionRotationEventArgs(Point3 position, Rotation rotation, bool onGround)
        {
            Position = position;
            Rotation = rotation;
            OnGround = onGround;
        }
    }
}
