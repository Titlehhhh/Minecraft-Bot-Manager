using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.IO;


namespace ProtocolLib340.Packets.Server
{

    
    public class ServerPlayerUseBedPacket : IPacket
    {
        //this.entityId = in.readVarInt();
       //this.position = NetUtil.readPosition(in);
        public void Read(IMinecraftStreamReader stream)
        {
            
        }

        public void Write(IMinecraftStreamWriter stream)
        {
            
        }

        public ServerPlayerUseBedPacket() {}
    }

}
