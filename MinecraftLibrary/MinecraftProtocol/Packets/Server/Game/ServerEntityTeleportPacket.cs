using MinecraftProtocol.IO;
using MinecraftProtocol.Packets;

namespace MinecraftLibrary.MinecraftProtocol.Packets.Server.Game
{
    public class ServerEntityTeleportPacket : ServerPacket
    {
        public int EntityID { get; private set; }
        public double X { get; private set; }
        public double Y { get; private set; }
        public double Z { get; private set; }
        public float Yaw { get; private set; }
        public float Pitch { get; private set; }
        public bool OnGround { get; private set; }
        public void Read(NetInput input, int version)
        {
            EntityID = input.ReadNextVarInt();
            X = input.ReadNextDouble();
            Y = input.ReadNextDouble();
            Z = input.ReadNextDouble();
            Yaw = input.ReadNextByte() * 360 / 256f;
            Pitch = input.ReadNextByte() * 360 / 256f;
            OnGround = input.ReadNextBool();

        }
    }


}
