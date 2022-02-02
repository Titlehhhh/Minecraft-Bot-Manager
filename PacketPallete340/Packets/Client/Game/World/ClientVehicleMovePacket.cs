using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Protocol.Helpres;

namespace PacketPallete340.Packets.Client.Game.World
{
    //out.writeDouble(this.x);
    //out.writeDouble(this.y);
    //out.writeDouble(this.z);
    //out.writeFloat(this.yaw);
    //out.writeFloat(this.pitch);
    [PacketMeta(0x10, 340, PacketSide.Client, PacketCategory.Game)]
    public class ClientVehicleMovePacket : ClientPacket
    {
        public override void Write(MinecraftStream output, int version)
        {
            
        }
    }
}
