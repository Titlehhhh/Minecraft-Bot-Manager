using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.IO;


namespace ProtocolLib340.Packets.Server.Game.Entity.Player
{

    
    public class ServerPlayerHealthPacket : IPacket
    {
        //this.health = in.readFloat();
       //this.food = in.readVarInt();
       //this.saturation = in.readFloat();
        public void Read(IMinecraftStreamReader stream)
        {
            
        }

        public void Write(IMinecraftStreamWriter stream)
        {
            
        }

        public ServerPlayerHealthPacket() {}
    }

}
