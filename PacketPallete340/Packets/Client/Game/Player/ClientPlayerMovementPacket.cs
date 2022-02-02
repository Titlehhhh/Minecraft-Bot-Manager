using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Protocol.Helpres;

namespace PacketPallete340.Packets.Client.Game.Player
{
    //if(this.pos) {
    //out.writeDouble(this.x);
    //out.writeDouble(this.y);
    //out.writeDouble(this.z);
    //}
    //
    //if(this.rot) {
    //out.writeFloat(this.yaw);
    //out.writeFloat(this.pitch);
    //}
    //
    //out.writeBoolean(this.onGround);
    [PacketMeta(0x0C, 340, PacketSide.Client, PacketCategory.Game)]
    public class ClientPlayerMovementPacket : ClientPacket
    {
        public override void Write(MinecraftStream output, int version)
        {
            
        }
    }
}
