using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Protocol.Helpres;

namespace PacketPallete340.Packets.Client.Game.Window
{
    //out.writeByte(this.windowId);
    //out.writeShort(this.actionId);
    //out.writeBoolean(this.accepted);
    [PacketMeta(0x05, 340, PacketSide.Client, PacketCategory.Game)]
    public class ClientConfirmTransactionPacket : ClientPacket
    {
        public override void Write(MinecraftStream output, int version)
        {
            
        }
    }
}
