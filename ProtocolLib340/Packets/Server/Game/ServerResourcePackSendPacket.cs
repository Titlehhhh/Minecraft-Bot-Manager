using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Server.Game
{

    [PacketInfo(0x34, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerResourcePackSendPacket : MinecraftPacket
    {
        //this.url = in.readString();
       //this.hash = in.readString();
        public override void Read(IMinecraftStreamReader input)
        {
            
        }
        public ServerResourcePackSendPacket() {}
    }

}
