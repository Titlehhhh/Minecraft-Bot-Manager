using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Server.Game
{

    [PacketInfo(0x35, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerRespawnPacket : MinecraftPacket
    {
        //this.dimension = in.readInt();
       //this.difficulty = MagicValues.key(Difficulty.class, in.readUnsignedByte());
       //this.gamemode = MagicValues.key(GameMode.class, in.readUnsignedByte());
       //this.worldType = MagicValues.key(WorldType.class, in.readString().toLowerCase());
        public override void Read(IMinecraftStreamReader input)
        {
            
        }
        public ServerRespawnPacket() {}
    }

}
