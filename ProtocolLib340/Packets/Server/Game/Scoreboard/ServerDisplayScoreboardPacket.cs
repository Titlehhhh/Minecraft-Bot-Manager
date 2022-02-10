using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Server.Game.Scoreboard
{

    [PacketInfo(0x3B, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerDisplayScoreboardPacket : MinecraftPacket
    {
        //this.position = MagicValues.key(ScoreboardPosition.class, in.readByte());
       //this.name = in.readString();
        public override void Read(IMinecraftStreamReader input)
        {
            
        }
        public ServerDisplayScoreboardPacket() {}
    }

}
