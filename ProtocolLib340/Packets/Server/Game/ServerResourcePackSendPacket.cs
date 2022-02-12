using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Server.Game
{

    [PacketHeader(0x34, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerResourcePackSendPacket : IPacket
    {
        //this.url = in.readString();
       //this.hash = in.readString();
        public void Read(MinecraftStream stream)
        {
            
        }

        public void Write(MinecraftStream stream)
        {
            
        }

        public ServerResourcePackSendPacket() {}
    }

}
