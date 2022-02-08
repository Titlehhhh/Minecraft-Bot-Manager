using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Protocol.Helpres;

namespace ProtocolLib340.Packets.Server.Game.World
{

    [PacketMeta(0x1C, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerExplosionPacket : MinecraftPacket
    {
        //this.x = in.readFloat();
       //this.y = in.readFloat();
       //this.z = in.readFloat();
       //this.radius = in.readFloat();
       //this.exploded = new ArrayList<ExplodedBlockRecord>();
       //int length = in.readInt();
       //for(int count = 0; count < length; count++) {
       //this.exploded.add(new ExplodedBlockRecord(in.readByte(), in.readByte(), in.readByte()));
       //}
       //
       //this.pushX = in.readFloat();
       //this.pushY = in.readFloat();
       //this.pushZ = in.readFloat();
        public override void Read(IMinecraftStreamReader input)
        {
            
        }
        public ServerExplosionPacket() {}
    }

}
