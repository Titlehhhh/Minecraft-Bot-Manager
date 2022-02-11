using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Server.Game.Entity
{

    [PacketInfo(0x3E, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerEntityVelocityPacket : IPacket
    {
        //this.entityId = in.readVarInt();
       //this.motX = in.readShort() / 8000D;
       //this.motY = in.readShort() / 8000D;
       //this.motZ = in.readShort() / 8000D;
        public override void Read(IMinecraftStreamReader input)
        {
            
        }
        public ServerEntityVelocityPacket() {}
    }

}
