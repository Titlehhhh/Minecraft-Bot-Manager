using McProtoNet.Geometry;

namespace MinecraftBotManager
{
    public interface IMove
    {
        Point3 Position { get; }
        Rotation Rotation { get; }
        bool OnGround { get; }

        void UpdateState(PhysicState physicState);

        void Shift(bool state);

    }
}
