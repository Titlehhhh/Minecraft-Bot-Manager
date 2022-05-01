using MinecraftLibrary.API;
using MinecraftLibrary.API.IO;
using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Protocol;


namespace ProtocolLib754.Packets.Client
{

    [PacketInfo(0x13, 754, PacketCategory.Game, PacketSide.Client)]
    public class ClientPlayerPositionRotationPacket : IPacket
    {
        public double X { get; private set; }
        public double Y { get; private set; }
        public double Z { get; private set; }
        public float Yaw { get; private set; }
        public float Pitch { get; private set; }
        public bool OnGround { get; private set; }

        public void Write(IMinecraftStreamWriter stream)
        {
            stream.WriteDouble(X);
            stream.WriteDouble(Y);
            stream.WriteDouble(Z);
            stream.WriteFloat(Yaw);
            stream.WriteFloat(Pitch);
            stream.WriteBoolean(OnGround);
        }
        public void Read(IMinecraftStreamReader stream)
        {
            X = stream.ReadDouble();
            Y = stream.ReadDouble();
            Z = stream.ReadDouble();
            Yaw = stream.ReadFloat();
            Pitch = stream.ReadFloat();
            OnGround = stream.ReadBoolean();
        }
        public ClientPlayerPositionRotationPacket() { }

        public ClientPlayerPositionRotationPacket(double X, double Y, double Z, float Yaw, float Pitch, bool OnGround)
        {
            this.X = X;
            this.Y = Y;
            this.Z = Z;
            this.Yaw = Yaw;
            this.Pitch = Pitch;
            this.OnGround = OnGround;
        }
    }
}
