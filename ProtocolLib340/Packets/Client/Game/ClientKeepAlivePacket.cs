using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.IO;


namespace ProtocolLib340.Packets.Client
{

    
    public class ClientKeepAlivePacket : IPacket
    {
        public long ID { get; set; }
        //out.writeLong(this.id);
        public void Write(IMinecraftStreamWriter stream)
        {
            stream.WriteLong(ID);
        }

        public void Read(IMinecraftStreamReader stream)
        {
            
        }

        public ClientKeepAlivePacket(long iD)
        {
            ID = iD;
        }
    }
}
