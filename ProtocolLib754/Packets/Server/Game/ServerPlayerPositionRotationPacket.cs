using MinecraftLibrary.API;
using MinecraftLibrary.API.IO;
using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Protocol;


namespace ProtocolLib754.Packets.Server
{

    [PacketInfo(0x34, 754, PacketCategory.Game, PacketSide.Server)]
    public class ServerPlayerPositionRotationPacket : IPacket
    {
        public double  X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public float Yaw { get; set; }
        public float Pitch { get; set; }
        public bool IsGround { get; set; }

        public int TeleportId { get; set; }
        public void Write(IMinecraftStreamWriter stream)
        {

        }
        public void Read(IMinecraftStreamReader stream)
        {

        }
        public ServerPlayerPositionRotationPacket() { }
    }
}

