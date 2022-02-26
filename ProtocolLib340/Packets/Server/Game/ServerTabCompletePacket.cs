using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.IO;


namespace ProtocolLib340.Packets.Server.Game
{

    
    public class ServerTabCompletePacket : IPacket
    {
        //this.matches = new String[in.readVarInt()];
       //for(int index = 0; index < this.matches.length; index++) {
       //this.matches[index] = in.readString();
       //}
        public void Read(IMinecraftStreamReader stream)
        {
            
        }

        public void Write(IMinecraftStreamWriter stream)
        {
            
        }

        public ServerTabCompletePacket() {}
    }

}
