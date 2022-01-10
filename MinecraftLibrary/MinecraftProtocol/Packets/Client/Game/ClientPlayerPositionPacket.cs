using MinecraftProtocol.IO;
using MinecraftProtocol.Packets;

namespace MinecraftLibrary.MinecraftProtocol.Packets.Client.Game
{
    public class ClientPlayerPositionPacket : ClientPlayerMovementPacket
    {
        public ClientPlayerPositionPacket(double x, double y, double z, bool onGround)
        {
            pos = true;
            X = x;
            Y = y;
            Z = z;
            OnGround = onGround;
        }
    }



}
