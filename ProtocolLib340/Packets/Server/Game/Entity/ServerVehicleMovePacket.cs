using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Server.Game.Entity
{

    [PacketHeader(0x29, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerVehicleMovePacket : IPacket
    {
        //this.x = in.readDouble();
       //this.y = in.readDouble();
       //this.z = in.readDouble();
       //this.yaw = in.readFloat();
       //this.pitch = in.readFloat();
        public void Read(MinecraftStream stream)
        {
            
        }

        public void Write(MinecraftStream stream)
        {
            
        }

        public ServerVehicleMovePacket() {}
    }

}
