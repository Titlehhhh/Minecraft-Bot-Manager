using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Server.Game.Entity.Player
{

    [PacketInfo(0x40, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerPlayerSetExperiencePacket : MinecraftPacket
    {
        //this.experience = in.readFloat();
       //this.level = in.readVarInt();
       //this.totalExperience = in.readVarInt();
        public override void Read(IMinecraftStreamReader input)
        {
            
        }
        public ServerPlayerSetExperiencePacket() {}
    }

}
