using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Protocol.Helpres;

namespace PacketPallete340.Packets.Client.Game.World
{
    //out.writeBoolean(this.rightPaddleTurning);
    //out.writeBoolean(this.leftPaddleTurning);
    [PacketMeta(0x11, 340, PacketSide.Client, PacketCategory.Game)]
    public class ClientSteerBoatPacket : ClientPacket
    {
        public override void Write(MinecraftStream output, int version)
        {
            
        }
    }
}
