using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Protocol.Helpres;

namespace PacketPallete340.Packets.Client.Game.Player
{
    //protected ClientPlayerRotationPacket() {
    //this.rot = true;
    //}
    //
    //public ClientPlayerRotationPacket(boolean onGround, float yaw, float pitch) {
    //super(onGround);
    //this.rot = true;
    //this.yaw = yaw;
    //this.pitch = pitch;
    //}
    [PacketMeta(0x0F, 340, PacketSide.Client, PacketCategory.Game)]
    public class ClientPlayerRotationPacket : ClientPacket
    {
        public override void Write(MinecraftStream output, int version)
        {
            
        }
    }
}
