using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Protocol.Helpres;

namespace ProtocolLib340.Packets.Server.Game
{

    [PacketMeta(0x48, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerTitlePacket : MinecraftPacket
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
        public override void Read(IMinecraftStreamReader input)
        {
            
        }
        public ServerTitlePacket() {}
    }

}
