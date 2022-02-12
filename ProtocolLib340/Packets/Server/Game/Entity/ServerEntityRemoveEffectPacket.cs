using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Server.Game.Entity
{

    [PacketHeader(0x33, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerEntityRemoveEffectPacket : IPacket
    {
        //this.entityId = in.readVarInt();
       //this.effect = MagicValues.key(Effect.class, in.readUnsignedByte());
        public void Read(MinecraftStream stream)
        {
            
        }

        public void Write(MinecraftStream stream)
        {
            
        }

        public ServerEntityRemoveEffectPacket() {}
    }

}
