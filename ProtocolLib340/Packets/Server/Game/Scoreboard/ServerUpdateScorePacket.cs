using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Server.Game.Scoreboard
{

    [PacketInfo(0x45, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerUpdateScorePacket : IPacket
    {
        //this.entry = in.readString();
       //this.action = MagicValues.key(ScoreboardAction.class, in.readVarInt());
       //this.objective = in.readString();
       //if(this.action == ScoreboardAction.ADD_OR_UPDATE) {
       //this.value = in.readVarInt();
       //}
        public void Read(MinecraftStream stream)
        {
            
        }

        public void Write(MinecraftStream stream)
        {
            
        }

        public ServerUpdateScorePacket() {}
    }

}
