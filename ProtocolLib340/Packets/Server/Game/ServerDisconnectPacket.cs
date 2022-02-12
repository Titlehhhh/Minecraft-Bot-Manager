using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Server.Game
{

    [PacketHeader(0x1A, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerDisconnectPacket : IPacket
    {
        //this.message = Message.fromString(in.readString());
        public void Read(MinecraftStream stream)
        {
            
        }

        public void Write(MinecraftStream stream)
        {
            
        }

        public ServerDisconnectPacket() {}
    }

}
