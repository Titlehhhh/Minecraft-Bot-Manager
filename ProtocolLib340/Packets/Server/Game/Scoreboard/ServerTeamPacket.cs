using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Protocol.Helpres;

namespace ProtocolLib340.Packets.Server.Game.Scoreboard
{

    [PacketMeta(0x44, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerTeamPacket : MinecraftPacket
    {
        //this.name = in.readString();
       //this.action = MagicValues.key(TeamAction.class, in.readByte());
       //if(this.action == TeamAction.CREATE || this.action == TeamAction.UPDATE) {
       //this.displayName = in.readString();
       //this.prefix = in.readString();
       //this.suffix = in.readString();
       //byte flags = in.readByte();
       //this.friendlyFire = (flags & 0x1) != 0;
       //this.seeFriendlyInvisibles = (flags & 0x2) != 0;
       //this.nameTagVisibility = MagicValues.key(NameTagVisibility.class, in.readString());
       //this.collisionRule = MagicValues.key(CollisionRule.class, in.readString());
       //
       //try {
       //this.color = MagicValues.key(TeamColor.class, in.readByte());
       //} catch(IllegalArgumentException e) {
       //this.color = TeamColor.NONE;
       //}
       //}
       //
       //if(this.action == TeamAction.CREATE || this.action == TeamAction.ADD_PLAYER || this.action == TeamAction.REMOVE_PLAYER) {
       //this.players = new String[in.readVarInt()];
       //for(int index = 0; index < this.players.length; index++) {
       //this.players[index] = in.readString();
       //}
       //}
        public override void Read(IMinecraftStreamReader input)
        {
            
        }
        public ServerTeamPacket() {}
    }

}
