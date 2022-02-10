using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Server.Game.Entity.Player
{

    [PacketInfo(0x30, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerPlayerUseBedPacket : MinecraftPacket
    {
        //this.entityId = in.readVarInt();
       //this.position = NetUtil.readPosition(in);
        public override void Read(IMinecraftStreamReader input)
        {
            
        }
        public ServerPlayerUseBedPacket() {}
    }

}
