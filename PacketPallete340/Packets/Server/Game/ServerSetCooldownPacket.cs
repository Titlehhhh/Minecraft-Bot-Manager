using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Protocol.Helpres;

namespace PacketPallete340.Packets.Server.Game
{

    [PacketMeta(0x17, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerSetCooldownPacket : MinecraftPacket
    {
        //this.itemId = in.readVarInt();
       //this.cooldownTicks = in.readVarInt();
        public override void Read(MinecraftStream output)
        {
            
        }
        public ServerSetCooldownPacket() {}
    }

}
