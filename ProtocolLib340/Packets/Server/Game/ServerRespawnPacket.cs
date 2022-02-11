using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Server.Game
{

    [PacketInfo(0x35, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerRespawnPacket : IPacket
    {
        //this.dimension = in.readInt();
       //this.difficulty = MagicValues.key(Difficulty.class, in.readUnsignedByte());
       //this.gamemode = MagicValues.key(GameMode.class, in.readUnsignedByte());
       //this.worldType = MagicValues.key(WorldType.class, in.readString().toLowerCase());
        public void Read(MinecraftStream stream)
        {
            
        }

        public void Write(MinecraftStream stream)
        {
            
        }

        public ServerRespawnPacket() {}
    }

}
