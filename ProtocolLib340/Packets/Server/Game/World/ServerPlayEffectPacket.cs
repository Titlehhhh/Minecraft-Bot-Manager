using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.IO;


namespace ProtocolLib340.Packets.Server
{

    
    public class ServerPlayEffectPacket : IPacket
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
        public void Read(IMinecraftStreamReader stream)
        {
            
        }

        public void Write(IMinecraftStreamWriter stream)
        {
            
        }

        public ServerPlayEffectPacket() {}
    }

}
