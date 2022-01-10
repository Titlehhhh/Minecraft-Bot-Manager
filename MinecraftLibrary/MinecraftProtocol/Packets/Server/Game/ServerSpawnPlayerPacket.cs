
using MinecraftLibrary.Data;
using MinecraftLibrary.Geometri;
using MinecraftProtocol.IO;
using MinecraftProtocol.Packets;
using System;

namespace MinecraftLibrary.MinecraftProtocol.Packets.Server.Game
{
    public class ServerSpawnPlayerPacket : ServerPacket
    {
        public int EntityID { get; private set; }
        public Guid UUID { get; private set; }
        public float Yaw { get; private set; }
        public float Pitch { get; private set; }
        public Point3 Position { get; private set; }
        public void Read(NetInput input, int version)
        {
            EntityID = input.ReadNextVarInt();
            UUID = input.ReadNextUUID();
            double X = input.ReadNextDouble();
            double Y = input.ReadNextDouble();
            double Z = input.ReadNextDouble();
            Yaw = input.ReadNextByte() * 360 / 256f;
            Pitch = input.ReadNextByte() * 360 / 256f;

            Position = new Point3(X, Y, Z);
        }
    }


}
