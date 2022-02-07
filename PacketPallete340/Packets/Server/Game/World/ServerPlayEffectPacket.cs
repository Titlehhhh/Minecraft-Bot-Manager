using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Protocol.Helpres;

namespace PacketPallete340.Packets.Server.Game.World
{

    [PacketMeta(0x21, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerPlayEffectPacket : MinecraftPacket
    {
        //this.effect = MagicValues.key(WorldEffect.class, in.readInt());
       //this.position = NetUtil.readPosition(in);
       //int value = in.readInt();
       //if(this.effect == SoundEffect.RECORD) {
       //this.data = new RecordEffectData(value);
       //} else if(this.effect == ParticleEffect.SMOKE) {
       //this.data = MagicValues.key(SmokeEffectData.class, value % 9);
       //} else if(this.effect == ParticleEffect.BREAK_BLOCK) {
       //this.data = new BreakBlockEffectData(new BlockState(value & 4095, (value >> 12) & 255));
       //} else if(this.effect == ParticleEffect.BREAK_SPLASH_POTION) {
       //this.data = new BreakPotionEffectData(value);
       //} else if(this.effect == ParticleEffect.BONEMEAL_GROW) {
       //this.data = new BonemealGrowEffectData(value);
       //}
       //
       //this.broadcast = in.readBoolean();
        public override void Read(IMinecraftStreamReader input)
        {
            
        }
        public ServerPlayEffectPacket() {}
    }

}
