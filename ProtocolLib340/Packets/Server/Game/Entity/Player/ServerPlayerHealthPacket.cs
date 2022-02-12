using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Server.Game.Entity.Player
{

    [PacketHeader(0x41, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerPlayerHealthPacket : IPacket
    {
        //this.health = in.readFloat();
       //this.food = in.readVarInt();
       //this.saturation = in.readFloat();
        public void Read(MinecraftStream stream)
        {
            
        }

        public void Write(MinecraftStream stream)
        {
            
        }

        public ServerPlayerHealthPacket() {}
    }

}
