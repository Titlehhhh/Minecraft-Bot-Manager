using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Server.Game.World
{

    [PacketInfo(0x0B, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerBlockChangePacket : MinecraftPacket
    {
        //this.record = new BlockChangeRecord(NetUtil.readPosition(in), NetUtil.readBlockState(in));
        public override void Read(IMinecraftStreamReader input)
        {
            
        }
        public ServerBlockChangePacket() {}
    }

}
