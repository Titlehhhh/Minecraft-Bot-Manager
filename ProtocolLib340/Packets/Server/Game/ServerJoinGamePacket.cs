using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Server.Game
{

    [PacketHeader(0x23, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerJoinGamePacket : IPacket
    {
        //this.entityId = in.readInt();
       //int gamemode = in.readUnsignedByte();
       //this.hardcore = (gamemode & 8) == 8;
       //gamemode &= -9;
       //this.gamemode = MagicValues.key(GameMode.class, gamemode);
       //this.dimension = in.readInt();
       //this.difficulty = MagicValues.key(Difficulty.class, in.readUnsignedByte());
       //this.maxPlayers = in.readUnsignedByte();
       //this.worldType = MagicValues.key(WorldType.class, in.readString().toLowerCase());
       //this.reducedDebugInfo = in.readBoolean();
        public void Read(MinecraftStream stream)
        {
            
        }

        public void Write(MinecraftStream stream)
        {
            
        }

        public ServerJoinGamePacket() {}
    }

}
