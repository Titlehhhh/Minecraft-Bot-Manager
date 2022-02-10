using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Server.Game.Entity.Player
{

    [PacketInfo(0x41, 340, PacketSide.Server, PacketCategory.Game)]
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
