using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Protocol.Helpres;

namespace PacketPallete340.Packets.Client.Game.Player
{
    //protected ClientPlayerPositionPacket() {
    //this.pos = true;
    //}
    //
    //public ClientPlayerPositionPacket(boolean onGround, double x, double y, double z) {
    //super(onGround);
    //this.pos = true;
    //this.x = x;
    //this.y = y;
    //this.z = z;
    //}
    [PacketMeta(0x0D, 340, PacketSide.Client, PacketCategory.Game)]
    public class ClientPlayerPositionPacket : ClientPacket
    {
        public override void Write(MinecraftStream output, int version)
        {
            
        }
    }
}
