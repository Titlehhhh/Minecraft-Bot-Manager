using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib740.Packets.Client.Game
{
    [PacketHeader(0x04, 740, PacketSide.Client, PacketCategory.Login)]
    public class ClientRequestPacket : IPacket
    {        
        public void Write(MinecraftStream stream)
        {
            
        }
        public void Read(MinecraftStream stream)
        {

        }
        public ClientRequestPacket() { }
    }
}
