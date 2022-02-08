using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Protocol.Helpres;

namespace ProtocolLib340.Packets.Server.Game.Entity.Player
{

    [PacketMeta(0x30, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerPlayerUseBedPacket : MinecraftPacket
    {
        //this.entityId = in.readVarInt();
       //this.position = NetUtil.readPosition(in);
        public override void Read(IMinecraftStreamReader input)
        {
            
        }
        public ServerPlayerUseBedPacket() {}
    }

}
