using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.IO;


namespace ProtocolLib340.Packets.Server.Game
{

    
    public class ServerBossBarPacket : IPacket
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
        public void Read(IMinecraftStreamReader stream)
        {
            
        }

        public void Write(IMinecraftStreamWriter stream)
        {
            
        }

        public ServerBossBarPacket() {}
    }

}
