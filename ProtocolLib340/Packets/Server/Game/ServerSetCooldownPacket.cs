using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.IO;


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

        public ServerSetCooldownPacket() {}
    }

}
