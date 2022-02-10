using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Server.Game.World
{

    [PacketInfo(0x46, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerSpawnPositionPacket : MinecraftPacket
    {
        //this.position = NetUtil.readPosition(in);
        public override void Read(IMinecraftStreamReader input)
        {
            
        }
        public ServerSpawnPositionPacket() {}
    }

}
