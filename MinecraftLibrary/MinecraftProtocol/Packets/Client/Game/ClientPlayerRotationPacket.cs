using MinecraftProtocol.IO;
using MinecraftProtocol.Packets;

namespace MinecraftLibrary.MinecraftProtocol.Packets.Client.Game
{
    public class ClientPlayerRotationPacket : ClientPlayerMovementPacket
    {
        public ClientPlayerRotationPacket()
        {
            rot = true;
        }

        public ClientPlayerRotationPacket(float yaw, float pitch, bool onGround)
        {
            rot = true;
            Yaw = yaw;
            Pitch = pitch;
            OnGround = onGround;
        }

    }



}
