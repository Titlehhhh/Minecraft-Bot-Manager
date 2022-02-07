using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Protocol.Helpres;

namespace PacketPallete340.Packets.Server.Game.Scoreboard
{

    [PacketMeta(0x42, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerScoreboardObjectivePacket : MinecraftPacket
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
