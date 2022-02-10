using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Client.Game.Player
{

    [PacketInfo(0x0D, 340, PacketSide.Client, PacketCategory.Game)]
    public class ClientPlayerPositionPacket : MinecraftPacket
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public bool OnGround { get; set; }

        public override void Write(IMinecraftStreamWriter output)
        {
            output.WriteDouble(X);
            output.WriteDouble(Y);
            output.WriteDouble(Z);
            output.WriteBool(OnGround);
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
