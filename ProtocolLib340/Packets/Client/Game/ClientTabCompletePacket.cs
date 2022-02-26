using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.IO;


namespace ProtocolLib340.Packets.Client.Game
{

    
    public class ClientTabCompletePacket : IPacket
    {
        public void Read(IMinecraftStreamReader stream)
        {
            
        }

        //out.writeString(this.text);
        //out.WriteBooleanean(this.assumeCommand);
        //out.WriteBooleanean(this.lookingAt != null);
        //if(this.lookingAt != null) {
        //NetUtil.writePosition(out, this.lookingAt);
        //}
        public void Write(IMinecraftStreamWriter stream)
        {
            
        }
    }
}
