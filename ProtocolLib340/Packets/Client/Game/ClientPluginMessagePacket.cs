using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.IO;


namespace ProtocolLib340.Packets.Client.Game
{

    
    public class ClientPluginMessagePacket : IPacket
    {
        public void Read(IMinecraftStreamReader stream)
        {
            
        }

        //out.writeString(this.channel);
        //out.writeBytes(this.data);
        public void Write(IMinecraftStreamWriter stream)
        {

        }
    }
}
