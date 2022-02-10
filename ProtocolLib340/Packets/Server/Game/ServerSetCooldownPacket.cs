using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Server.Game
{

    [PacketInfo(0x17, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerSetCooldownPacket : MinecraftPacket
    {
        //this.itemId = in.readVarInt();
       //this.cooldownTicks = in.readVarInt();
        public override void Read(IMinecraftStreamReader input)
        {
            
        }
        public ServerSetCooldownPacket() {}
    }

}
