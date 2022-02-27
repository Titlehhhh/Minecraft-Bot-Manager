using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.IO;


namespace ProtocolLib340.Packets.Server
{

    
    public class ServerCloseWindowPacket : IPacket
    {
        //this.windowId = in.readUnsignedByte();
        public void Read(IMinecraftStreamReader stream)
        {
            
        }

        public void Write(IMinecraftStreamWriter stream)
        {
            
        }

        public ServerCloseWindowPacket() {}
    }

}
