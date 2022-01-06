using MinecraftProtocol.IO;
using MinecraftProtocol.Packets;

namespace MinecraftLibrary.MinecraftProtocol.Packets.Client.Game
{
    public class ClientPlayerPositionAndRotationPacket : ClientPlayerMovementPacket
    {
        public ClientPlayerPositionAndRotationPacket(double x, double y, double z, float yaw, float pitch, bool onGround)
        {
            pos = true;
            rot = true;
            X = x;
            Y = y;
            Z = z;
            Yaw = yaw;
            Pitch = pitch;
            OnGround = onGround;
        }
        public ClientPlayerPositionAndRotationPacket()
        {

        }
        

    }



}
