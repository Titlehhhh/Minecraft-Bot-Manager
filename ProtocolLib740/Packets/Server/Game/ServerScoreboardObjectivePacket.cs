using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API;
using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.IO;


namespace ProtocolLib740.Packets.Server
{
    
    [PacketInfo(0x4A, 740, PacketCategory.Game, PacketSide.Server)]
    public class ServerScoreboardObjectivePacket : IPacket
    {        
        public void Write(IMinecraftStreamWriter stream)
        {
            
        }
        public void Read(IMinecraftStreamReader stream)
        {

        }
        public ServerScoreboardObjectivePacket() { }
    }
}

