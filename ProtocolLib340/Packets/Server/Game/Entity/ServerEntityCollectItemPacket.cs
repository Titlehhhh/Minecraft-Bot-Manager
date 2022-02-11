using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Server.Game.Entity
{

    [PacketInfo(0x4B, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerEntityCollectItemPacket : IPacket
    {
        //this.collectedEntityId = in.readVarInt();
       //this.collectorEntityId = in.readVarInt();
       //this.itemCount = in.readVarInt();
        public void Read(MinecraftStream stream)
        {
            
        }

        public void Write(MinecraftStream stream)
        {
            
        }

        public ServerEntityCollectItemPacket() {}
    }

}
