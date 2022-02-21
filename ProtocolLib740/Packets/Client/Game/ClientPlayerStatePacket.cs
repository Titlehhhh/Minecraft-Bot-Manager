using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib740.Packets.Client.Game
{
    [PacketHeader(0x1C, 740, PacketSide.Client, PacketCategory.Login)]
    public class ClientPlayerStatePacket : IPacket
    {        
        public void Write(MinecraftStream stream)
        {
            
        }
        public void Read(MinecraftStream stream)
        {

        }
        public ClientPlayerStatePacket() { }
    }
}
