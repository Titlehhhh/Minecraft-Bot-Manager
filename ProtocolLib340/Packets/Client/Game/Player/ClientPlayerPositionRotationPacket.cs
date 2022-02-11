using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Client.Game.Player
{

    [PacketInfo(0x0E, 340, PacketSide.Client, PacketCategory.Game)]
    public class ClientPlayerPositionRotationPacket : IPacket
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public float Yaw { get; set; }
        public float Pitch { get; set; }

        public bool OnGround { get; set; }
        
        public override void Write(IMinecraftStreamWriter output)
        {
            output.WriteDouble(X);
            output.WriteDouble(Y);
            output.WriteDouble(Z);
            output.WriteFloat(Yaw);
            output.WriteFloat(Pitch);
            output.WriteBool(OnGround);
        }
        
        public ClientPlayerPositionRotationPacket(double x, double y, double z, float yaw, float pitch, bool onGround)
        {
            X = x;
            Y = y;
            Z = z;
            Yaw = yaw;
            Pitch = pitch;
            OnGround = onGround;
        }
    }
}
