using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Protocol.Helpres;

namespace PacketPallete340.Packets.Client.Game.Window
{

    [PacketMeta(0x08, 340, PacketSide.Client, PacketCategory.Game)]
    public class ClientCloseWindowPacket : ClientPacket
    {
        //out.writeByte(this.windowId);
        public override void Write(MinecraftStream output)
        {
            
        }
    }
}
