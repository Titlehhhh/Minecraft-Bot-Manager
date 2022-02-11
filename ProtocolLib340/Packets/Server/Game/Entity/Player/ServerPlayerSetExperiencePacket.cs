using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Server.Game.Entity.Player
{

    [PacketInfo(0x40, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerPlayerSetExperiencePacket : IPacket
    {
        //this.experience = in.readFloat();
       //this.level = in.readVarInt();
       //this.totalExperience = in.readVarInt();
        public void Read(MinecraftStream stream)
        {
            
        }

        public void Write(MinecraftStream stream)
        {
            
        }

        public ServerPlayerSetExperiencePacket() {}
    }

}
