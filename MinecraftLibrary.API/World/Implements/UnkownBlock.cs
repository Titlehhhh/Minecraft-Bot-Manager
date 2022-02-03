using MinecraftLibrary.Geometry;

namespace MinecraftLibrary.API.World.Implements
{
    public sealed class UnkownBlock : IBlock
    {
        public Point3_Int Position => new Point3_Int(0, 0, 0);

        public int ID => 0;
    }
}
