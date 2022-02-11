using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Server.Game.World
{

    [PacketInfo(0x46, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerSpawnPositionPacket : IPacket
    {
        //this.position = NetUtil.readPosition(in);
        public void Read(MinecraftStream stream)
        {
            
        }

        public void Write(MinecraftStream stream)
        {
            
        }

        public ServerSpawnPositionPacket() {}
    }

}
