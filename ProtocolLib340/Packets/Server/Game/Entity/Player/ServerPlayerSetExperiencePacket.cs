using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.IO;


namespace ProtocolLib340.Packets.Server.Game.Entity.Player
{

    
    public class ServerPlayerSetExperiencePacket : IPacket
    {
        //this.experience = in.readFloat();
       //this.level = in.readVarInt();
       //this.totalExperience = in.readVarInt();
        public void Read(IMinecraftStreamReader stream)
        {
            
        }

        public void Write(IMinecraftStreamWriter stream)
        {
            
        }

        public ServerPlayerSetExperiencePacket() {}
    }

}
