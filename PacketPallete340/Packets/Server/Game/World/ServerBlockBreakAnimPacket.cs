using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Protocol.Helpres;

namespace PacketPallete340.Packets.Server.Game.World
{

    [PacketMeta(0x08, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerBlockBreakAnimPacket : MinecraftPacket
    {
        //this.breakerEntityId = in.readVarInt();
       //this.position = NetUtil.readPosition(in);
       //try {
       //this.stage = MagicValues.key(BlockBreakStage.class, in.readUnsignedByte());
       //} catch(IllegalArgumentException e) {
       //this.stage = BlockBreakStage.RESET;
       //}
        public override void Read(IMinecraftStreamReader input)
        {
            
        }
        public ServerBlockBreakAnimPacket() {}
    }

}
