using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Server.Game
{

    [PacketHeader(0x17, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerSetCooldownPacket : IPacket
    {
        //this.itemId = in.readVarInt();
       //this.cooldownTicks = in.readVarInt();
        public void Read(MinecraftStream stream)
        {
            
        }

        public void Write(MinecraftStream stream)
        {
            
        }

        public ServerSetCooldownPacket() {}
    }

}
