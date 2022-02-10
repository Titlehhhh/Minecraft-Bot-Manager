using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Server.Game.Entity
{

    [PacketInfo(0x33, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerEntityRemoveEffectPacket : MinecraftPacket
    {
        //this.entityId = in.readVarInt();
       //this.effect = MagicValues.key(Effect.class, in.readUnsignedByte());
        public override void Read(IMinecraftStreamReader input)
        {
            
        }
        public ServerEntityRemoveEffectPacket() {}
    }

}
