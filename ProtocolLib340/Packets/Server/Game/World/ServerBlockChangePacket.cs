using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.IO;


namespace ProtocolLib340.Packets.Server
{

    
    public class ServerBlockChangePacket : IPacket
    {
        //this.record = new BlockChangeRecord(NetUtil.readPosition(in), NetUtil.readBlockState(in));
        public void Read(IMinecraftStreamReader stream)
        {
            
        }

        public void Write(IMinecraftStreamWriter stream)
        {
            
        }

        public ServerBlockChangePacket() {}
    }

}
