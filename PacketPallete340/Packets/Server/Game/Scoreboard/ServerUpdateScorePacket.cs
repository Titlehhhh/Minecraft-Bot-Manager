using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Protocol.Helpres;

namespace PacketPallete340.Packets.Server.Game.Scoreboard
{

    [PacketMeta(0x45, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerUpdateScorePacket : MinecraftPacket
    {
        //this.entry = in.readString();
       //this.action = MagicValues.key(ScoreboardAction.class, in.readVarInt());
       //this.objective = in.readString();
       //if(this.action == ScoreboardAction.ADD_OR_UPDATE) {
       //this.value = in.readVarInt();
       //}
        public override void Read(IMinecraftStreamReader input)
        {
            
        }
        public ServerUpdateScorePacket() {}
    }

}
