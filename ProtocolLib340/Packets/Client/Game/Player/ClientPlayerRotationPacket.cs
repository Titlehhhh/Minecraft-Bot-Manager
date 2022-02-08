using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Protocol.Helpres;

namespace ProtocolLib340.Packets.Client.Game.Player
{

    [PacketMeta(0x0F, 340, PacketSide.Client, PacketCategory.Game)]
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
