using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Server.Game
{

    [PacketInfo(0x2D, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerCombatPacket : IPacket
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
        public override void Read(IMinecraftStreamReader input)
        {
            
        }
        public ServerCombatPacket() {}
    }

}
