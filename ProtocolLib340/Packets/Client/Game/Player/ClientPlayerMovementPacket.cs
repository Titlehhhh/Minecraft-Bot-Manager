using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Protocol.Helpres;

namespace ProtocolLib340.Packets.Client.Game.Player
{

    [PacketMeta(0x0C, 340, PacketSide.Client, PacketCategory.Game)]
    public class ClientPlayerMovementPacket : MinecraftPacket
    {
        public bool OnGround { get; set; }        
        public override void Write(IMinecraftStreamWriter output)
        {
            output.WriteBool(OnGround);
        }
        public ClientPlayerMovementPacket()
        {

        }
        public ClientPlayerMovementPacket(bool onGround)
        {
            OnGround = onGround;
        }
    }
}
