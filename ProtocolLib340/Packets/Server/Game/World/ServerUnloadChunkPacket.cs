using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Protocol.Helpres;

namespace ProtocolLib340.Packets.Server.Game.World
{

    [PacketMeta(0x1D, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerUnloadChunkPacket : MinecraftPacket
    {
        //this.x = in.readInt();
       //this.z = in.readInt();
        public override void Read(IMinecraftStreamReader input)
        {
            
        }
        public ServerUnloadChunkPacket() {}
    }

}
