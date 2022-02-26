using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.IO;


namespace ProtocolLib340.Packets.Server.Game
{

    
    public class ServerResourcePackSendPacket : IPacket
    {
        //this.url = in.readString();
       //this.hash = in.readString();
        public void Read(IMinecraftStreamReader stream)
        {
            
        }

        public void Write(IMinecraftStreamWriter stream)
        {
            
        }

        public ServerResourcePackSendPacket() {}
    }

}
