using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Protocol.Helpres;

namespace ProtocolLib340.Packets.Server.Game
{

    [PacketMeta(0x1F, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerKeepAlivePacket : MinecraftPacket
    {
        public long ID { get; set; }
        
        public override void Read(IMinecraftStreamReader input)
        {
            ID = input.ReadNextLong();
        }

        public ServerKeepAlivePacket(long iD)
        {
            ID = iD;
        }

        public ServerKeepAlivePacket() {}
    }

}
