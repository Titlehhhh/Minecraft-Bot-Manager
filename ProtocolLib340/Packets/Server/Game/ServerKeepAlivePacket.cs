using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Server.Game
{

    [PacketInfo(0x1F, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerKeepAlivePacket : IPacket
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
