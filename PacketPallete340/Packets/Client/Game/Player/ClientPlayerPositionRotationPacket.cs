using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Protocol.Helpres;

namespace PacketPallete340.Packets.Client.Game.Player
{
    //protected ClientPlayerPositionRotationPacket() {
    //this.pos = true;
    //this.rot = true;
    //}
    //
    //public ClientPlayerPositionRotationPacket(boolean onGround, double x, double y, double z, float yaw, float pitch) {
    //super(onGround);
    //this.pos = true;
    //this.rot = true;
    //this.x = x;
    //this.y = y;
    //this.z = z;
    //this.yaw = yaw;
    //this.pitch = pitch;
    //}
    [PacketMeta(0x0E, 340, PacketSide.Client, PacketCategory.Game)]
    public class ClientPlayerPositionRotationPacket : ClientPacket
    {
        public override void Write(MinecraftStream output, int version)
        {
            
        }
    }
}
