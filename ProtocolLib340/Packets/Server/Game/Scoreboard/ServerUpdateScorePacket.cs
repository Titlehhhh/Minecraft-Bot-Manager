using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.IO;


namespace ProtocolLib340.Packets.Server.Game.Scoreboard
{

    
    public class ServerUpdateScorePacket : IPacket
    {
        //this.entry = in.readString();
       //this.action = MagicValues.key(ScoreboardAction.class, in.readVarInt());
       //this.objective = in.readString();
       //if(this.action == ScoreboardAction.ADD_OR_UPDATE) {
       //this.value = in.readVarInt();
       //}
        public void Read(IMinecraftStreamReader stream)
        {
            
        }

        public void Write(IMinecraftStreamWriter stream)
        {
            
        }

        public ServerUpdateScorePacket() {}
    }

}
