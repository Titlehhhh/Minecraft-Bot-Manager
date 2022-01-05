using MinecraftProtocol.IO;
using MinecraftProtocol.Packets;

namespace MinecraftLibrary.MinecraftProtocol.Packets.Client.Game
{
    public class ClientPlayerPositionAndRotationPacket : ClientPacket
    {
        public ClientPlayerPositionAndRotationPacket(double x, double y, double z, float yaw, float pitch, bool onGround)
        {
            X = x;
            Y = y;
            Z = z;
            Yaw = yaw;
            Pitch = pitch;
            OnGround = onGround;
        }
        public ClientPlayerPositionAndRotationPacket()
        {

        }

        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public float Yaw { get; set; }
        public float Pitch { get; set; }
        public bool OnGround { get; set; }
        public void Write(NetOutput output, int version)
        {
            output.WriteDouble(X);
            output.WriteDouble(Y);
            output.WriteDouble(Z);
            output.WriteFloat(Yaw);
            output.WriteFloat(Pitch);
            output.WriteBool(OnGround);

        }
    }



}
