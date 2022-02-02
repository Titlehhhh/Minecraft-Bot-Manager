using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Protocol.Helpres;

namespace PacketPallete340.Packets.Client.Game
{
    //out.writeLong(this.id);
    [PacketMeta(0x0B, 340, PacketSide.Client, PacketCategory.Game)]
    public class ClientKeepAlivePacket : ClientPacket
    {
        public override void Write(MinecraftStream output, int version)
        {
            
        }
    }
}
