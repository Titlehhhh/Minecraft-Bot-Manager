using MinecraftLibrary.API.IO;
using MinecraftLibrary.API.Networking;


namespace ProtocolLib340.Packets.Server
{


    public class ServerSpawnPositionPacket : IPacket
    {
        //this.position = NetUtil.readPosition(in);
        public void Read(IMinecraftStreamReader stream)
        {

        }

        public void Write(IMinecraftStreamWriter stream)
        {

        }

        public ServerSpawnPositionPacket() { }
    }

}
