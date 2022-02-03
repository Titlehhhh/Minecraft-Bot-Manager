using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Protocol.Helpres;

namespace PacketPallete340.Packets.Client.Game.Player
{

    [PacketMeta(0x0E, 340, PacketSide.Client, PacketCategory.Game)]
    public class ClientPlayerPositionRotationPacket : ClientPacket
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public float Yaw { get; set; }
        public float Pitch { get; set; }

        public bool OnGround { get; set; }
        
        public override void Write(MinecraftStream output)
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
