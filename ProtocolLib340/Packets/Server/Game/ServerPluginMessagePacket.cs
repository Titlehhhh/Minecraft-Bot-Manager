using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.IO;


namespace ProtocolLib340.Packets.Server.Game
{

    
    public class ServerPluginMessagePacket : IPacket
    {
        //this.channel = in.readString();
       //this.data = in.readBytes(in.available());
        public void Read(IMinecraftStreamReader stream)
        {
            
        }

        public void Write(IMinecraftStreamWriter stream)
        {
            
        }

        public ServerPluginMessagePacket() {}
    }

}
