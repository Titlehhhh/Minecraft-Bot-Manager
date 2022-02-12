using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Client.Game.World
{

    [PacketHeader(0x10, 340, PacketSide.Client, PacketCategory.Game)]
    public class ClientVehicleMovePacket : IPacket
    {
        public void Read(MinecraftStream stream)
        {
            
        }

        //out.writeDouble(this.x);
        //out.writeDouble(this.y);
        //out.writeDouble(this.z);
        //out.writeFloat(this.yaw);
        //out.writeFloat(this.pitch);
        public void Write(MinecraftStream stream)
        {
            
        }
    }
}
