using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Server.Game
{
    [PacketHeader(0x0F, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerChatPacket : IPacket
    {               

        public void Read(MinecraftStream stream)
        {
            
        }

        public void Write(MinecraftStream stream)
        {
            
        }
    }

}
