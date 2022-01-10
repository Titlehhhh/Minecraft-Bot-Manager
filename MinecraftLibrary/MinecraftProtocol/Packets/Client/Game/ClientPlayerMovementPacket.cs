using MinecraftProtocol.IO;
using MinecraftProtocol.Packets;

namespace MinecraftLibrary.MinecraftProtocol.Packets.Client.Game
{
    public class ClientPlayerMovementPacket : ClientPacket
    {
        protected bool rot = false;
        protected bool pos = false;

        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public float Yaw { get; set; }
        public float Pitch { get; set; }
        public bool OnGround { get; set; }
        public void Write(NetOutput output, int version)
        {
            if (this.pos)
            {
                output.WriteDouble(this.X);
                output.WriteDouble(this.Y);
                output.WriteDouble(this.Z);
            }

            if (this.rot)
            {
                output.WriteFloat(this.Yaw);
                output.WriteFloat(this.Pitch);
            }
            output.WriteBool(this.OnGround);
        }

    }



}
