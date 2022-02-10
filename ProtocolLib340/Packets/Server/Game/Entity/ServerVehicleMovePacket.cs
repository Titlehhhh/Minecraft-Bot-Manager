using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Server.Game.Entity
{

    [PacketInfo(0x29, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerVehicleMovePacket : MinecraftPacket
    {
        //this.x = in.readDouble();
       //this.y = in.readDouble();
       //this.z = in.readDouble();
       //this.yaw = in.readFloat();
       //this.pitch = in.readFloat();
        public override void Read(IMinecraftStreamReader input)
        {
            
        }
        public ServerVehicleMovePacket() {}
    }

}
