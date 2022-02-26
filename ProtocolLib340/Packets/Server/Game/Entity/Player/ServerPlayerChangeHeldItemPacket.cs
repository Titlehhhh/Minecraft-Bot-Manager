using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.IO;


namespace ProtocolLib340.Packets.Server.Game.Entity.Player
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

        public ServerPlayerChangeHeldItemPacket() {}
    }

}
