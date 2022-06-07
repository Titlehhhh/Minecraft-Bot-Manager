using McProtoNet.Geometry;

namespace MinecraftBotManager.API
{
    public interface IMove
    {
        Point3 Position { get; }
        Rotation Rotation { get; }
        bool OnGround { get; }

        void UpdatePosition(Point3 point, bool onGround);

        void UpdatePosition(Rotation rotation, bool onGround);

        void UpdatePosition(Point3 point, Rotation rotation, bool onGround);

        void UpdatePosition(bool onGround);




        bool Shift { get; set; }

    }
}
