using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
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
