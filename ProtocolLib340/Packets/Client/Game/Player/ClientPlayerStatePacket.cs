using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Protocol.Helpres;

namespace ProtocolLib340.Packets.Client.Game.Player
{

    [PacketMeta(0x15, 340, PacketSide.Client, PacketCategory.Game)]
    public class ClientPlayerStatePacket : MinecraftPacket
    {
        //out.writeVarInt(this.entityId);
       //out.writeVarInt(MagicValues.value(Integer.class, this.state));
       //out.writeVarInt(this.jumpBoost);
        public override void Write(IMinecraftStreamWriter output)
        {
            
        }
    }
}
