using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Protocol.Helpres;

namespace PacketPallete340.Packets.Server.Game
{

    [PacketMeta(0x2D, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerCombatPacket : MinecraftPacket
    {
        //this.state = MagicValues.key(CombatState.class, in.readVarInt());
       //if(this.state == CombatState.END_COMBAT) {
       //this.duration = in.readVarInt();
       //this.entityId = in.readInt();
       //} else if(this.state == CombatState.ENTITY_DEAD) {
       //this.playerId = in.readVarInt();
       //this.entityId = in.readInt();
       //this.message = Message.fromString(in.readString());
       //}
        public override void Read(MinecraftStream output)
        {
            
        }
        public ServerCombatPacket() {}
    }

}
