using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Protocol.Helpres;

namespace ProtocolLib340.Packets.Client.Game.World
{

    [PacketMeta(0x10, 340, PacketSide.Client, PacketCategory.Game)]
    public class ClientVehicleMovePacket : MinecraftPacket
    {
        //out.writeDouble(this.x);
       //out.writeDouble(this.y);
       //out.writeDouble(this.z);
       //out.writeFloat(this.yaw);
       //out.writeFloat(this.pitch);
        public override void Write(IMinecraftStreamWriter output)
        {
            
        }
    }
}