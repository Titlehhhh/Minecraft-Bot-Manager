using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.IO;


namespace ProtocolLib340.Packets.Client.Game
{
    
    public class ClientCloseWindowPacket : IPacket
    {
        public void Read(IMinecraftStreamReader stream)
        {
            
        }

        //out.writeByte(this.windowId);
        public void Write(IMinecraftStreamWriter stream)
        {
            
        }
    }
}
