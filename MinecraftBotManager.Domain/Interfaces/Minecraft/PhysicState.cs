using McProtoNet.Geometry;

namespace MinecraftBotManager
{
    public struct PhysicState
    {
        public Point3 Position { get; set; }
        public Rotation Rotation { get; set; }
        public bool OnGround { get; set; }
    }
}
