using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib740.Packets.Server.Game
{
    [PacketHeader(0x49, 740, PacketSide.Server, PacketCategory.Login)]
    public class ServerPlayerHealthPacket : IPacket
    {        
        public void Write(MinecraftStream stream)
        {
            
        }
        public void Read(MinecraftStream stream)
        {

        }
        public ServerPlayerHealthPacket() { }
    }
}