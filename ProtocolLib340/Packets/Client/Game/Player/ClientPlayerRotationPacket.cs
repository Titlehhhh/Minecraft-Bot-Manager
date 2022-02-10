using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Client.Game.Player
{

    [PacketInfo(0x0F, 340, PacketSide.Client, PacketCategory.Game)]
    public class ClientPlayerRotationPacket : MinecraftPacket
    {
        public float Yaw { get; set; }
        public float Pitch { get; set; }
        public bool OnGround { get; set; }

        public override void Write(IMinecraftStreamWriter output)
        {
            output.WriteFloat(Yaw);
            output.WriteFloat(Pitch);
            output.WriteBool(OnGround);
        }

        public ClientPlayerRotationPacket(float yaw, float pitch, bool onGround)
        {
            Yaw = yaw;
            Pitch = pitch;
            OnGround = onGround;
        }
    }
}
