using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Protocol.Helpres;

namespace PacketPallete340.Packets.Client.Game
{

    [PacketMeta(0x09, 340, PacketSide.Client, PacketCategory.Game)]
    public class ClientPluginMessagePacket : MinecraftPacket
    {
        //out.writeString(this.channel);
        //out.writeBytes(this.data);
        public override void Write(MinecraftStream output)
        {

        }
    }
}
