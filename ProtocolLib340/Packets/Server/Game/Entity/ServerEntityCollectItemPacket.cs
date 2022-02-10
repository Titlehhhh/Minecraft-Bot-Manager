using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Server.Game.Entity
{

    [PacketInfo(0x4B, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerEntityCollectItemPacket : MinecraftPacket
    {
        //this.collectedEntityId = in.readVarInt();
       //this.collectorEntityId = in.readVarInt();
       //this.itemCount = in.readVarInt();
        public override void Read(IMinecraftStreamReader input)
        {
            
        }
        public ServerEntityCollectItemPacket() {}
    }

}
