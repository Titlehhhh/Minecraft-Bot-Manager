using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Protocol.Helpres;

namespace ProtocolLib340.Packets.Server.Game.Entity.Player
{

    [PacketMeta(0x41, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerPlayerHealthPacket : MinecraftPacket
    {
        //this.health = in.readFloat();
       //this.food = in.readVarInt();
       //this.saturation = in.readFloat();
        public override void Read(IMinecraftStreamReader input)
        {
            
        }
        public ServerPlayerHealthPacket() {}
    }

}
