using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Client.Game.Player
{

    [PacketInfo(0x0A, 340, PacketSide.Client, PacketCategory.Game)]
    public class ClientPlayerInteractEntityPacket : IPacket
    {
        public void Read(MinecraftStream stream)
        {
            
        }

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
        public void Write(MinecraftStream stream)
        {
            
        }
    }
}
