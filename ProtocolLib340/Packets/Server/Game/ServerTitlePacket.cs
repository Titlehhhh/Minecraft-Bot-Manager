using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.IO;


namespace ProtocolLib340.Packets.Server
{

    
    public class ServerTitlePacket : IPacket
    {
        //this.action = MagicValues.key(TitleAction.class, in.readVarInt());
       //switch(this.action) {
       //case TITLE:
       //this.title = Message.fromString(in.readString());
       //break;
       //case SUBTITLE:
       //this.subtitle = Message.fromString(in.readString());
       //break;
       //case ACTION_BAR:
       //this.actionBar = Message.fromString(in.readString());
       //break;
       //case TIMES:
       //this.fadeIn = in.readInt();
       //this.stay = in.readInt();
       //this.fadeOut = in.readInt();
       //break;
       //case CLEAR:
       //break;
       //case RESET:
       //break;
       //}
        public void Read(IMinecraftStreamReader stream)
        {
            
        }

        public void Write(IMinecraftStreamWriter stream)
        {
            
        }

        public ServerTitlePacket() {}
    }

}
