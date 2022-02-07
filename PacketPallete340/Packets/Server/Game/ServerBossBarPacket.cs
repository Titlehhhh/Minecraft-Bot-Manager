using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Protocol.Helpres;

namespace PacketPallete340.Packets.Server.Game
{

    [PacketMeta(0x0C, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerBossBarPacket : MinecraftPacket
    {
        //this.uuid = in.readUUID();
       //this.action = MagicValues.key(BossBarAction.class, in.readVarInt());
       //
       //if(this.action == BossBarAction.ADD || this.action == BossBarAction.UPDATE_TITLE) {
       //this.title = Message.fromString(in.readString());
       //}
       //
       //if(this.action == BossBarAction.ADD || this.action == BossBarAction.UPDATE_HEALTH) {
       //this.health = in.readFloat();
       //}
       //
       //if(this.action == BossBarAction.ADD || this.action == BossBarAction.UPDATE_STYLE) {
       //this.color = MagicValues.key(BossBarColor.class, in.readVarInt());
       //this.division = MagicValues.key(BossBarDivision.class, in.readVarInt());
       //}
       //
       //if(this.action == BossBarAction.ADD || this.action == BossBarAction.UPDATE_FLAGS) {
       //int flags = in.readUnsignedByte();
       //this.darkenSky = (flags & 0x1) == 0x1;
       //this.dragonBar = (flags & 0x2) == 0x2;
       //}
        public override void Read(IMinecraftStreamReader input)
        {
            
        }
        public ServerBossBarPacket() {}
    }

}
