using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Protocol.Helpres;

namespace PacketPallete340.Packets.Server.Game.World
{

    [PacketMeta(0x47, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerUpdateTimePacket : MinecraftPacket
    {
        //this.age = in.readLong();
       //this.time = in.readLong();
        public override void Read(MinecraftStream output)
        {
            
        }
        public ServerUpdateTimePacket() {}
    }

}
