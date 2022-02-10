using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Server.Game.World
{

    [PacketInfo(0x19, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerPlaySoundPacket : MinecraftPacket
    {
        //String value = in.readString();
       //try {
       //this.sound = MagicValues.key(BuiltinSound.class, value);
       //} catch(IllegalArgumentException e) {
       //this.sound = new CustomSound(value);
       //}
       //
       //this.category = MagicValues.key(SoundCategory.class, in.readVarInt());
       //this.x = in.readInt() / 8D;
       //this.y = in.readInt() / 8D;
       //this.z = in.readInt() / 8D;
       //this.volume = in.readFloat();
       //this.pitch = in.readFloat();
        public override void Read(IMinecraftStreamReader input)
        {
            
        }
        public ServerPlaySoundPacket() {}
    }

}
