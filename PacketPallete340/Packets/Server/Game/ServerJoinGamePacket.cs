using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Protocol.Helpres;

namespace PacketPallete340.Packets.Server.Game
{

    [PacketMeta(0x23, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerJoinGamePacket : MinecraftPacket
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
        public override void Read(IMinecraftStreamReader input)
        {
            
        }
        
        public ServerJoinGamePacket() {}
    }

}
