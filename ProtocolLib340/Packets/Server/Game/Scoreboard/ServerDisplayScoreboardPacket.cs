using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.IO;


namespace ProtocolLib340.Packets.Server
{

    
    public class ServerDisplayScoreboardPacket : IPacket
    {
        //this.position = MagicValues.key(ScoreboardPosition.class, in.readByte());
       //this.name = in.readString();
        public void Read(IMinecraftStreamReader stream)
        {
            
        }

        public void Write(IMinecraftStreamWriter stream)
        {
            
        }

        public ServerDisplayScoreboardPacket() {}
    }

}
