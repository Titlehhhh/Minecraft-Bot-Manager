using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API;
using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.IO;


namespace ProtocolLib740.Packets.Server
{
    
    [PacketInfo(0x0E, 740, PacketCategory.Game, PacketSide.Server)]
    public class ServerChatPacket : IPacket
    {        
        public void Write(IMinecraftStreamWriter stream)
        {
            
        }
        public void Read(IMinecraftStreamReader stream)
        {

        }
        public ServerChatPacket() { }
    }
}

