using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Protocol.Helpres;

namespace PacketPallete340.Packets.Client.Game
{
    //out.writeString(this.message);
    [PacketMeta(0x02, 340, PacketSide.Client, PacketCategory.Game)]
    public class ClientChatPacket : ClientPacket
    {
        public override void Write(MinecraftStream output, int version)
        {
            
        }
    }
}
