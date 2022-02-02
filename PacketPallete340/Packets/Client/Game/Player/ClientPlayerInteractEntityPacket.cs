using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Protocol.Helpres;

namespace PacketPallete340.Packets.Client.Game.Player
{
    //out.writeVarInt(this.entityId);
    //out.writeVarInt(MagicValues.value(Integer.class, this.action));
    //if(this.action == InteractAction.INTERACT_AT) {
    //out.writeFloat(this.targetX);
    //out.writeFloat(this.targetY);
    //out.writeFloat(this.targetZ);
    //}
    //
    //if(this.action == InteractAction.INTERACT || this.action == InteractAction.INTERACT_AT) {
    //out.writeVarInt(MagicValues.value(Integer.class, this.hand));
    //}
    [PacketMeta(0x0A, 340, PacketSide.Client, PacketCategory.Game)]
    public class ClientPlayerInteractEntityPacket : ClientPacket
    {
        public override void Write(MinecraftStream output, int version)
        {
            
        }
    }
}
