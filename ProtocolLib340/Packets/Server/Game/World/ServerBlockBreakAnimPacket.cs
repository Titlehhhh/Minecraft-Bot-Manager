using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Server.Game.World
{

    [PacketInfo(0x08, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerBlockBreakAnimPacket : IPacket
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
