using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API;
using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.IO;


namespace ProtocolLib740.Packets.Server
{
    
    [PacketInfo(0x37, 740, PacketCategory.Game, PacketSide.Server)]    public class ServerEntityRemoveEffectPacket : IPacket
    {        
        public void Write(IMinecraftStreamWriter stream)
        {
            
        }
        public void Read(IMinecraftStreamReader stream)
        {

        }
        public ServerEntityRemoveEffectPacket() { }
    }
}

