using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Helpres;
using MinecraftLibrary.Core.Protocol.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftLibrary.Core.Protocol.Packets.Client.Game.Player
{
    [PacketMetaGame(0x14)]
    public class ClientPlayerMovementPacket : ClientPacket
    {
        public bool Onground { get; set; }
        public override void Write(MinecraftStream output, int version)
        {
            output.WriteBool(Onground);
        }

        public ClientPlayerMovementPacket(bool isOnground)
        {
            Onground = isOnground;
        }
    }
    [PacketMetaGame(0x13)]
    public class ClientPlayerRotationPacket : ClientPlayerMovementPacket
    {
        public ClientPlayerRotationPacket(float yaw, float pitch, bool isOnground) : base(isOnground)
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
    [PacketMetaGame(0x11)]
    public class ClientPlayerPositionPacket : ClientPlayerMovementPacket
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public ClientPlayerPositionPacket(double x, double y, double z, bool onground) : base(onground)
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
    [PacketMetaGame(0x12)]
    public class ClientPlayerPositionAndRotationPacket : ClientPlayerMovementPacket
    {
        public ClientPlayerPositionAndRotationPacket(double x, double y, double z, float yaw, float pitch, bool isOnground) : base(isOnground)
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
