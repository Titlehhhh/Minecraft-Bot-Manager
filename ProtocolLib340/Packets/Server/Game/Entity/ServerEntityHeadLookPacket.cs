using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Server.Game.Entity
{

    [PacketHeader(0x36, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerEntityHeadLookPacket : IPacket
    {
        //this.entityId = in.readVarInt();
       //this.headYaw = in.readByte() * 360 / 256f;
        public void Read(MinecraftStream stream)
        {
            
        }

        public void Write(MinecraftStream stream)
        {
            
        }

        public ServerEntityHeadLookPacket() {}
    }

}
