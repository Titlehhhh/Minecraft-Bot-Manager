using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Protocol.Helpres;

namespace ProtocolLib340.Packets.Server.Game.Entity
{

    [PacketMeta(0x06, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerEntityAnimationPacket : MinecraftPacket
    {
        //this.entityId = in.readVarInt();
       //this.animation = MagicValues.key(Animation.class, in.readUnsignedByte());
        public override void Read(IMinecraftStreamReader input)
        {
            
        }
        public ServerEntityAnimationPacket() {}
    }

}
