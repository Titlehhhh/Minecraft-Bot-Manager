using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Protocol.Helpres;

namespace PacketPallete340.Packets.Server.Game.Entity
{

    [PacketMeta(0x1B, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerEntityStatusPacket : MinecraftPacket
    {
        //this.entityId = in.readInt();
       //this.status = MagicValues.key(EntityStatus.class, in.readByte());
        public override void Read(IMinecraftStreamReader input)
        {
            
        }
        public ServerEntityStatusPacket() {}
    }

}
