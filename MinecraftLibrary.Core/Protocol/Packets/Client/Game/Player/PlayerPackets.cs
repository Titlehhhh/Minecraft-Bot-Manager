using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Helpres;
using MinecraftLibrary.API.Protocol.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftLibrary.Core.Protocol.Packets.Client.Game.Player
{
    [PacketMetaGame(0x14,740)]
    public class ClientPlayerMovementPacket740 : ClientPacket
    {
        public bool Onground { get; set; }
        public override void Write(MinecraftStream output, int version)
        {
            output.WriteBool(Onground);
        }

        public ClientPlayerMovementPacket740(bool isOnground)
        {
            Onground = isOnground;
        }
    }
    [PacketMetaGame(0x13,740)]
    public class ClientPlayerRotationPacket740 : ClientPlayerMovementPacket740
    {
        public ClientPlayerRotationPacket740(float yaw, float pitch, bool isOnground) : base(isOnground)
        {
            Yaw = yaw;
            Pitch = pitch;
        }

        public float Yaw { get; set; }
        public float Pitch { get; set; }
        public override void Write(MinecraftStream output, int version)
        {
            output.WriteFloat(Yaw);
            output.WriteFloat(Pitch);
            base.Write(output, version);
        }
    }
    [PacketMetaGame(0x11,740)]
    public class ClientPlayerPositionPacket740 : ClientPlayerMovementPacket740
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public ClientPlayerPositionPacket740(double x, double y, double z, bool onground) : base(onground)
        {
            X = x;
            Y = y;
            Z = z;
        }
        public override void Write(MinecraftStream output, int version)
        {
            output.WriteDouble(X);
            output.WriteDouble(Y);
            output.WriteDouble(Z);
            base.Write(output, version);
        }
    }
    [PacketMetaGame(0x12,740)]
    public class ClientPlayerPositionAndRotationPacket740 : ClientPlayerMovementPacket740
    {
        public ClientPlayerPositionAndRotationPacket740(double x, double y, double z, float yaw, float pitch, bool isOnground) : base(isOnground)
        {
            X = x;
            Y = y;
            Z = z;
            Yaw = yaw;
            Pitch = pitch;
        }

        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public float Yaw { get; set; }
        public float Pitch { get; set; }
        public override void Write(MinecraftStream output, int version)
        {
            output.WriteDouble(X);
            output.WriteDouble(Y);
            output.WriteDouble(Z);
            output.WriteFloat(Yaw);
            output.WriteFloat(Pitch);
            base.Write(output, version);
        }


    }
}
