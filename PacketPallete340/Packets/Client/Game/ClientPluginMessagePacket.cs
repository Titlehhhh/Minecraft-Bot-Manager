using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Protocol.Helpres;

namespace PacketPallete340.Packets.Client.Game
{
    //out.writeString(this.channel);
    //out.writeBytes(this.data);
    [PacketMeta(0x09, 340, PacketSide.Client, PacketCategory.Game)]
    public class ClientPluginMessagePacket : ClientPacket
    {
        public override void Write(MinecraftStream output, int version)
        {
            
        }
    }
}
