using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.IO;


namespace ProtocolLib340.Packets.Server.Game
{

    
    public class ServerPlayerListDataPacket : IPacket
    {
        //this.header = Message.fromString(in.readString());
       //this.footer = Message.fromString(in.readString());
        public void Read(IMinecraftStreamReader stream)
        {
            
        }

        public void Write(IMinecraftStreamWriter stream)
        {
            
        }

        public ServerPlayerListDataPacket() {}
    }

}
