using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Client.Game.World
{

    [PacketHeader(0x11, 340, PacketSide.Client, PacketCategory.Game)]
    public class ClientSteerBoatPacket : IPacket
    {
        public void Read(MinecraftStream stream)
        {
            
        }

        //out.WriteBooleanean(this.rightPaddleTurning);
        //out.WriteBooleanean(this.leftPaddleTurning);
        public void Write(MinecraftStream stream)
        {
            
        }
    }
}
