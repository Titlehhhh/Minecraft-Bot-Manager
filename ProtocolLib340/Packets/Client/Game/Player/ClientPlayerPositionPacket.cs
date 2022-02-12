using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Client.Game.Player
{

    [PacketHeader(0x0D, 340, PacketSide.Client, PacketCategory.Game)]
    public class ClientPlayerPositionPacket : IPacket
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public bool OnGround { get; set; }

        public void Write(MinecraftStream stream)
        {
            stream.WriteDouble(X);
            stream.WriteDouble(Y);
            stream.WriteDouble(Z);
            stream.WriteBoolean(OnGround);
        }

        public void Read(MinecraftStream stream)
        {
            
        }

        public ClientPlayerPositionPacket(double x, double y, double z, bool onGround)
        {
            X = x;
            Y = y;
            Z = z;
            OnGround = onGround;
        }
    }
}
