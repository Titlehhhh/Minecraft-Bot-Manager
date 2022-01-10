using MinecraftProtocol.IO;
using MinecraftProtocol.Packets;

namespace MinecraftLibrary.MinecraftProtocol.Packets.Client.Game
{
    public class ClientPlayerRotationPacket : ClientPlayerMovementPacket
    {
        public ClientPlayerRotationPacket(float yaw,float pitch, bool isGround)
        {
            rot = true;
            Yaw = yaw;
            Pitch = pitch;
            OnGround = isGround;
        }
    }



}
