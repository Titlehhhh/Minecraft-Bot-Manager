using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Protocol.Helpres;

namespace ProtocolLib340.Packets.Server.Game.Entity
{

    [PacketMeta(0x3D, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerEntityAttachPacket : MinecraftPacket
    {
        //this.entityId = in.readInt();
       //this.attachedToId = in.readInt();
        public override void Read(IMinecraftStreamReader input)
        {
            
        }
        public ServerEntityAttachPacket() {}
    }

}
