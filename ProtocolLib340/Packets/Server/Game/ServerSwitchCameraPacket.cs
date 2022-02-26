using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.IO;


namespace ProtocolLib340.Packets.Server.Game
{

    
    public class ServerSwitchCameraPacket : IPacket
    {
        //this.cameraEntityId = in.readVarInt();
        public void Read(IMinecraftStreamReader stream)
        {
            
        }

        public void Write(IMinecraftStreamWriter stream)
        {
            
        }

        public ServerSwitchCameraPacket() {}
    }

}
