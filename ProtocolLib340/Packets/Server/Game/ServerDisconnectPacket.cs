using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Server.Game
{

    [PacketInfo(0x1A, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerDisconnectPacket : IPacket
    {
        //this.message = Message.fromString(in.readString());
        public override void Read(IMinecraftStreamReader input)
        {
            
        }
        public ServerDisconnectPacket() {}
    }

}
