using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Protocol.Helpres;

namespace ProtocolLib340.Packets.Server.Game.World
{

    [PacketMeta(0x49, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerPlayBuiltinSoundPacket : MinecraftPacket
    {
        //this.sound = MagicValues.key(BuiltinSound.class, in.readVarInt());
       //this.category = MagicValues.key(SoundCategory.class, in.readVarInt());
       //this.x = in.readInt() / 8D;
       //this.y = in.readInt() / 8D;
       //this.z = in.readInt() / 8D;
       //this.volume = in.readFloat();
       //this.pitch = in.readFloat();
        public override void Read(IMinecraftStreamReader input)
        {
            
        }
        public ServerPlayBuiltinSoundPacket() {}
    }

}
