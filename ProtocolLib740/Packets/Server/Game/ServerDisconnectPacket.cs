using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib740.Packets.Server.Game
{
    [PacketHeader(0x19, 740, PacketSide.Client, PacketCategory.Login)]
    public class ServerDisconnectPacket : IPacket
    {        
        public void Write(MinecraftStream stream)
        {
            
        }
        public void Read(MinecraftStream stream)
        {

        }
        public ServerDisconnectPacket() { }
    }
}
