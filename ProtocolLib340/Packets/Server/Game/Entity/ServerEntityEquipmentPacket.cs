using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.IO;


namespace ProtocolLib340.Packets.Server.Game.Entity
{

    
    public class ServerEntityEquipmentPacket : IPacket
    {
        //this.entityId = in.readVarInt();
       //this.slot = MagicValues.key(EquipmentSlot.class, in.readVarInt());
       //this.item = NetUtil.readItem(in);
        public void Read(IMinecraftStreamReader stream)
        {
            
        }

        public void Write(IMinecraftStreamWriter stream)
        {
            
        }

        public ServerEntityEquipmentPacket() {}
    }

}
