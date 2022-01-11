using MinecraftLibrary.Data;
using MinecraftLibrary.Geometri;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModulesLibrary
{
    public static class Movement
    {
        public static Point3 HandleGravity(World world, Point3 location, ref double motionY)
        {
            Point3 onFoots = new Point3(location.X, Math.Floor(location.Y), location.Z);
            Point3 belowFoots = Move(location, Direction.Down);
            if (location.Y > Math.Truncate(location.Y) + 0.0001)
            {
                belowFoots = location;
                belowFoots.Y = Math.Truncate(location.Y);
            }
            if (!IsOnGround(world, location) && !IsSwimming(world, location))
            {
                while (!IsOnGround(world, belowFoots) && belowFoots.Y >= 1)
                    belowFoots = Move(belowFoots, Direction.Down);
                location = Move2Steps(location, belowFoots, ref motionY);
            }
            else if (!(world.GetBlock(onFoots).Type.IsSolid()))
                location = Move2Steps(location, onFoots, ref motionY);
            return location;
        }

        public static Point3 Move2Steps(Point3 start, Point3 goal, ref double motionY)
        {
            //Use MC-Like falling algorithm
            double Y = start.Y;
            Queue<Point3> fallSteps = new Queue<Point3>();
            fallSteps.Enqueue(start);            
            motionY -= 0.08D;
            motionY *= 0.9800000190734863D;
            Y += motionY;
            if (Y < goal.Y)
               return goal;
            else return new Point3(start.X, Y, start.Z);
        }



        public static bool IsOnGround(World world, Point3 location)
        {
            return world.GetBlock(Move(location, Direction.Down)).Type.IsSolid()
                  && (location.Y <= Math.Truncate(location.Y) + 0.0001);
        }
        public static bool IsSwimming(World world, Point3 location)
        {
            return world.GetBlock(location).Type.IsLiquid();
        }

        public static Point3 Move(Point3 location, Direction direction, int length = 1)
        {
            return location + Move(direction) * length;
        }

        /// <summary>
        /// Get a location delta for moving in the specified direction
        /// </summary>
        /// <param name="direction">Direction to move to</param>
        /// <returns>A location delta for moving in that direction</returns>
        public static Point3 Move(Direction direction)
        {
            switch (direction)
            {
                case Direction.Down:
                    return new Point3(0, -1, 0);
                case Direction.Up:
                    return new Point3(0, 1, 0);
                case Direction.East:
                    return new Point3(1, 0, 0);
                case Direction.West:
                    return new Point3(-1, 0, 0);
                case Direction.South:
                    return new Point3(0, 0, 1);
                case Direction.North:
                    return new Point3(0, 0, -1);
                default:
                    throw new ArgumentException("Unknown direction", "direction");
            }
        }
    }
}
