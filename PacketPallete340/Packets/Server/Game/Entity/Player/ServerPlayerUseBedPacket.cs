using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Protocol.Helpres;

namespace PacketPallete340.Packets.Server.Game.Entity.Player
{

    [PacketMeta(0x30, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerPlayerUseBedPacket : MinecraftPacket
    {
        //this.entityId = in.readVarInt();
       //this.position = NetUtil.readPosition(in);
        public override void Read(MinecraftStream output)
        {
            
        }
        public ServerPlayerUseBedPacket() {}
    }

}
