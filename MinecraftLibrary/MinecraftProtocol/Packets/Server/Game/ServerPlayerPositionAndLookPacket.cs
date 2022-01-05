using MinecraftProtocol.IO;
using MinecraftProtocol.Packets;

namespace MinecraftLibrary.MinecraftProtocol.Packets.Server.Game
{
    public class ServerPlayerPositionAndLookPacket : ServerPacket
    {
        public double X { get; private set; }
        public double Y { get; private set; }
        public double Z { get; private set; }
        public bool OnGround { get; private set; }
        public float Yaw { get; private set; }
        public float Pitch { get; private set; }
        public int TeleportID { get; private set; }
        public byte LocMask { get; private set; }
        public void Read(NetInput input, int version)
        {
            X = input.ReadNextDouble();
            Y = input.ReadNextDouble();
            Z = input.ReadNextDouble();
            Yaw = input.ReadNextFloat();
            Pitch = input.ReadNextFloat();
            LocMask = input.ReadNextByte();
            TeleportID = input.ReadNextVarInt();
            


        }
    }


}
