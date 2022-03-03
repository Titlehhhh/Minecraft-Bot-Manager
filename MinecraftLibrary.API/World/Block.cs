using MinecraftLibrary.Geometry;

namespace MinecraftLibrary.API.World
{
    public interface IBlock
    {
        int ID { get; set; }
        Point3_Int Position { get; set; }

    }
}
