using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.IO;


namespace ProtocolLib340.Packets.Server.Game.Entity
{

    
    public class ServerVehicleMovePacket : IPacket
    {
        //this.x = in.readDouble();
       //this.y = in.readDouble();
       //this.z = in.readDouble();
       //this.yaw = in.readFloat();
       //this.pitch = in.readFloat();
        public void Read(IMinecraftStreamReader stream)
        {
            
        }

        public void Write(IMinecraftStreamWriter stream)
        {
            
        }

        public ServerVehicleMovePacket() {}
    }

}
