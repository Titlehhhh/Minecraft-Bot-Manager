using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib740.Packets.Server.Game
{
    [PacketHeader(0x35, 740, PacketSide.Server, PacketCategory.Login)]
    public class ServerUnlockRecipesPacket : IPacket
    {        
        public void Write(MinecraftStream stream)
        {
            
        }
        public void Read(MinecraftStream stream)
        {

        }
        public ServerUnlockRecipesPacket() { }
    }
}