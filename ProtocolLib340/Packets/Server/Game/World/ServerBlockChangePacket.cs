using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Protocol.Helpres;

namespace ProtocolLib340.Packets.Server.Game.World
{

    [PacketMeta(0x0B, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerBlockChangePacket : MinecraftPacket
    {
        //this.record = new BlockChangeRecord(NetUtil.readPosition(in), NetUtil.readBlockState(in));
        public override void Read(IMinecraftStreamReader input)
        {
            
        }
        public ServerBlockChangePacket() {}
    }

}
