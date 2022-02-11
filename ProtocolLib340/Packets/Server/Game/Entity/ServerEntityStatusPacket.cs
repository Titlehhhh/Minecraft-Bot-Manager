using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Server.Game.Entity
{

    [PacketInfo(0x1B, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerEntityStatusPacket : IPacket
    {
        //this.entityId = in.readInt();
       //this.status = MagicValues.key(EntityStatus.class, in.readByte());
        public void Read(MinecraftStream stream)
        {
            
        }

        public void Write(MinecraftStream stream)
        {
            
        }

        public ServerEntityStatusPacket() {}
    }

}
