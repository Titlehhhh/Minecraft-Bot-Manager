using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Protocol.Helpres;

namespace PacketPallete340.Packets.Server.Game.Entity
{

    [PacketMeta(0x29, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerVehicleMovePacket : MinecraftPacket
    {
        //this.x = in.readDouble();
       //this.y = in.readDouble();
       //this.z = in.readDouble();
       //this.yaw = in.readFloat();
       //this.pitch = in.readFloat();
        public override void Read(MinecraftStream output)
        {
            
        }
        public ServerVehicleMovePacket() {}
    }

}
