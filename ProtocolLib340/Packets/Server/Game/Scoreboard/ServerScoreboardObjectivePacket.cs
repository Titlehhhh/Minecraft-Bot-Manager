using MinecraftLibrary.API.IO;
using MinecraftLibrary.API.Networking;


namespace ProtocolLib340.Packets.Server
{


    public class ServerScoreboardObjectivePacket : IPacket
    {
        //this.name = in.readString();
        //this.action = MagicValues.key(ObjectiveAction.class, in.readByte());
        //if(this.action == ObjectiveAction.ADD || this.action == ObjectiveAction.UPDATE) {
        //this.displayName = in.readString();
        //this.type = MagicValues.key(ScoreType.class, in.readString());
        //}
        public void Read(IMinecraftStreamReader stream)
        {

        }

        public void Write(IMinecraftStreamWriter stream)
        {

        }

        public ServerScoreboardObjectivePacket() { }
    }

}
