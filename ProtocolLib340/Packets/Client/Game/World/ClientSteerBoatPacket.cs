using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Client.Game.World
{

    [PacketInfo(0x11, 340, PacketSide.Client, PacketCategory.Game)]
    public class ClientSteerBoatPacket : MinecraftPacket
    {
        //out.writeBoolean(this.rightPaddleTurning);
       //out.writeBoolean(this.leftPaddleTurning);
        public override void Write(IMinecraftStreamWriter output)
        {
            
        }
    }
}
