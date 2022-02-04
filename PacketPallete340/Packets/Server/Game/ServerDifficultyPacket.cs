using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Protocol.Helpres;

namespace PacketPallete340.Packets.Server.Game
{

    [PacketMeta(0x0D, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerDifficultyPacket : MinecraftPacket
    {
        //this.difficulty = MagicValues.key(Difficulty.class, in.readUnsignedByte());
        public override void Read(MinecraftStream output)
        {
            
        }
        public ServerDifficultyPacket() {}
    }

}
