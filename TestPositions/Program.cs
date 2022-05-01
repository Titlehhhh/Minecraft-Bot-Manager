

using MinecraftLibrary.API.IO;
using MinecraftLibrary.Geometry;

namespace Gh
{
    public static class Program
    {
        private static int POSITION_X_SIZE = 38;
        private static int POSITION_Y_SIZE = 12;
        private static int POSITION_Z_SIZE = 38;
        private static int POSITION_Y_SHIFT = 0xFFF;
        private static int POSITION_WRITE_SHIFT = 0x3FFFFFF;

        public static void Main()
        {
            Console.WriteLine("start");
            Test();
        }
        static void Test()
        {
            for (int x = 0; x < int.MaxValue; x++)
                for (int y = 0; y < int.MaxValue; y++)
                    for (int z = 0; z < int.MaxValue; z++)
                    {
                        MinecraftStream ms = new MinecraftStream();
                        Point3_Int before = new Point3_Int(x, y, z);
                        ms.WritePos(before);
                        Point3_Int after = ms.ReadPos();
                        if (!(after.X == before.X && after.Y == before.Y && after.Z == before.Z))
                        {
                            Console.WriteLine($"Не сходиться: {x} {y} {z}");
                            return;

                        }
                    }
        }
        static void WritePos(this MinecraftStream stream, Point3_Int pos)
        {
            long x = pos.X & POSITION_WRITE_SHIFT;
            long y = pos.Y & POSITION_Y_SHIFT;
            long z = pos.Z & POSITION_WRITE_SHIFT;

            stream.WriteLong(x << POSITION_X_SIZE | y << POSITION_Y_SIZE | z);
        }
        static Point3_Int ReadPos(this MinecraftStream stream)
        {
            long val = stream.ReadLong();

            int x = (int)(val >> POSITION_X_SIZE);
            int y = (int)((val >> POSITION_Y_SIZE) & POSITION_Y_SHIFT);
            int z = (int)((val << POSITION_Z_SIZE) >> POSITION_Z_SIZE);

            return new Point3_Int(x, y, z);
        }
    }
}
