using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Server.Game.Scoreboard
{

    [PacketInfo(0x44, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerTeamPacket : IPacket
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
        public void Read(MinecraftStream stream)
        {
            
        }

        public void Write(MinecraftStream stream)
        {
            
        }

        public ServerTeamPacket() {}
    }

}
