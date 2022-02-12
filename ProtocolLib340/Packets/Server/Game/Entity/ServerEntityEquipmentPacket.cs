using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Server.Game.Entity
{

    [PacketHeader(0x3F, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerEntityEquipmentPacket : IPacket
    {
        //this.entityId = in.readVarInt();
       //this.slot = MagicValues.key(EquipmentSlot.class, in.readVarInt());
       //this.item = NetUtil.readItem(in);
        public void Read(MinecraftStream stream)
        {
            
        }

        public void Write(MinecraftStream stream)
        {
            
        }

        public ServerEntityEquipmentPacket() {}
    }

}
