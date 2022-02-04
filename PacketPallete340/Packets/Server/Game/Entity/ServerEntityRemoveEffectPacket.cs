using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Protocol.Helpres;

namespace PacketPallete340.Packets.Server.Game.Entity
{

    [PacketMeta(0x33, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerEntityRemoveEffectPacket : MinecraftPacket
    {
        //this.entityId = in.readVarInt();
       //this.effect = MagicValues.key(Effect.class, in.readUnsignedByte());
        public override void Read(MinecraftStream output)
        {
            
        }
        public ServerEntityRemoveEffectPacket() {}
    }

}
