using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Protocol.Helpres;

namespace ProtocolLib340.Packets.Server.Game.Entity.Player
{

    [PacketMeta(0x40, 340, PacketSide.Server, PacketCategory.Game)]
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
