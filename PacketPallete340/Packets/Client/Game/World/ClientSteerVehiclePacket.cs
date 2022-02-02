using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Protocol.Helpres;

namespace PacketPallete340.Packets.Client.Game.World
{
    //out.writeFloat(this.sideways);
    //out.writeFloat(this.forward);
    //byte flags = 0;
    //if(this.jump) {
    //flags = (byte) (flags | 1);
    //}
    //
    //if(this.dismount) {
    //flags = (byte) (flags | 2);
    //}
    //
    //out.writeByte(flags);
    [PacketMeta(0x16, 340, PacketSide.Client, PacketCategory.Game)]
    public class ClientSteerVehiclePacket : ClientPacket
    {
        public override void Write(MinecraftStream output, int version)
        {
            
        }
    }
}
