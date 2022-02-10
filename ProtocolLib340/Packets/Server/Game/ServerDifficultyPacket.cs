using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Server.Game
{

    [PacketInfo(0x0D, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerDifficultyPacket : MinecraftPacket
    {
        //this.difficulty = MagicValues.key(Difficulty.class, in.readUnsignedByte());
        public override void Read(IMinecraftStreamReader input)
        {
            
        }
        public ServerDifficultyPacket() {}
    }

}
