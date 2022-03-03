using MinecraftLibrary.API.IO;
using MinecraftLibrary.API.Networking;


namespace ProtocolLib340.Packets.Client.Game
{

    public class ClientCloseWindowPacket : IPacket
    {
        public void Read(IMinecraftStreamReader stream)
        {

        }

        //out.writeByte(this.windowId);
        public void Write(IMinecraftStreamWriter stream)
        {

        }
    }
}
