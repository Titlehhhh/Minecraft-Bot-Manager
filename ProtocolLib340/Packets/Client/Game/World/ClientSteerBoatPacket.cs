using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Protocol.Helpres;

namespace ProtocolLib340.Packets.Client.Game.World
{

    [PacketMeta(0x11, 340, PacketSide.Client, PacketCategory.Game)]
    public class ClientSteerBoatPacket : MinecraftPacket
    {
        //out.writeBoolean(this.rightPaddleTurning);
       //out.writeBoolean(this.leftPaddleTurning);
        public override void Write(IMinecraftStreamWriter output)
        {
            
        }
    }
}
