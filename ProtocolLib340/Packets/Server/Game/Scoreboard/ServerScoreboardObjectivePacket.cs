using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Server.Game.Scoreboard
{

    [PacketInfo(0x42, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerScoreboardObjectivePacket : IPacket
    {
        //this.name = in.readString();
       //this.action = MagicValues.key(ObjectiveAction.class, in.readByte());
       //if(this.action == ObjectiveAction.ADD || this.action == ObjectiveAction.UPDATE) {
       //this.displayName = in.readString();
       //this.type = MagicValues.key(ScoreType.class, in.readString());
       //}
        public override void Read(IMinecraftStreamReader input)
        {
            
        }
        public ServerScoreboardObjectivePacket() {}
    }

}
