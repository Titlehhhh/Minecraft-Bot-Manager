using MinecraftLibrary.API.IO;
using MinecraftLibrary.API.Networking;


namespace ProtocolLib340.Packets.Server
{


    public class ServerSetCooldownPacket : IPacket
    {
        //this.itemId = in.readVarInt();
        //this.cooldownTicks = in.readVarInt();
        public void Read(IMinecraftStreamReader stream)
        {

        }

        public void Write(IMinecraftStreamWriter stream)
        {

        }

        public ServerSetCooldownPacket() { }
    }

}
