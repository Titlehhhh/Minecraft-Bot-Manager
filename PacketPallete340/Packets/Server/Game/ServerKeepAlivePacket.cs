using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Protocol.Helpres;

namespace PacketPallete340.Packets.Server.Game
{

    [PacketMeta(0x1F, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerKeepAlivePacket : MinecraftPacket
    {
        public long ID { get; set; }
        
        public override void Read(MinecraftStream output)
        {
            ID = output.ReadNextLong();
        }

        public ServerKeepAlivePacket(long iD)
        {
            ID = iD;
        }

        public ServerKeepAlivePacket() {}
    }

}