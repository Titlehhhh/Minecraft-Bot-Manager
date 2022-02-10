using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Server.Game.Entity
{

    [PacketInfo(0x36, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerEntityHeadLookPacket : MinecraftPacket
    {
        //this.entityId = in.readVarInt();
       //this.headYaw = in.readByte() * 360 / 256f;
        public override void Read(IMinecraftStreamReader input)
        {
            
        }
        public ServerEntityHeadLookPacket() {}
    }

}
