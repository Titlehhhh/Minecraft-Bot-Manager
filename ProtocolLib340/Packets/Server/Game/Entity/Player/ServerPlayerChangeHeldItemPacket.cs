using MinecraftLibrary.API.IO;
using MinecraftLibrary.API.Networking;


namespace ProtocolLib340.Packets.Server
{


    public class ServerPlayerChangeHeldItemPacket : IPacket
    {
        //this.slot = in.readByte();
        public void Read(IMinecraftStreamReader stream)
        {

        }

        public void Write(IMinecraftStreamWriter stream)
        {

        }

        public ServerPlayerChangeHeldItemPacket() { }
    }

}
