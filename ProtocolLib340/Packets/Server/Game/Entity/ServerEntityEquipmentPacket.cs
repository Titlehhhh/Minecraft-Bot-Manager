using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Server.Game.Entity
{

    [PacketInfo(0x3F, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerEntityEquipmentPacket : MinecraftPacket
    {
        //this.entityId = in.readVarInt();
       //this.slot = MagicValues.key(EquipmentSlot.class, in.readVarInt());
       //this.item = NetUtil.readItem(in);
        public override void Read(IMinecraftStreamReader input)
        {
            
        }
        public ServerEntityEquipmentPacket() {}
    }

}
