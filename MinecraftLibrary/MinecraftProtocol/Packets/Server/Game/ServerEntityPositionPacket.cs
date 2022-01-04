using MinecraftProtocol.IO;
using MinecraftProtocol.Packets;
using System;

namespace MinecraftLibrary.MinecraftProtocol.Packets.Server.Game
{
    public class ServerEntityPositionPacket : ServerPacket
    {
        public int EntityID { get; private set; }
        public double DeltaX { get; private set; }
        public double DeltaY { get; private set; }
        public double DeltaZ { get; private set; }
        public bool OnGround { get; private set; }
        public void Read(NetInput input, int version)
        {
            EntityID = input.ReadNextVarInt();
            DeltaX = Convert.ToDouble(input.ReadNextShort()) / 4096;
            DeltaY = Convert.ToDouble(input.ReadNextShort()) / 4096;
            DeltaZ = Convert.ToDouble(input.ReadNextShort()) / 4096;

            OnGround = input.ReadNextBool();

        }
    }


}
