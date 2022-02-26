using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.IO;


namespace ProtocolLib340.Packets.Server.Game.World
{

    
    public class ServerPlayBuiltinSoundPacket : IPacket
    {
        //this.sound = MagicValues.key(BuiltinSound.class, in.readVarInt());
       //this.category = MagicValues.key(SoundCategory.class, in.readVarInt());
       //this.x = in.readInt() / 8D;
       //this.y = in.readInt() / 8D;
       //this.z = in.readInt() / 8D;
       //this.volume = in.readFloat();
       //this.pitch = in.readFloat();
        public void Read(IMinecraftStreamReader stream)
        {
            
        }

        public void Write(IMinecraftStreamWriter stream)
        {
            
        }

        public ServerPlayBuiltinSoundPacket() {}
    }

}
