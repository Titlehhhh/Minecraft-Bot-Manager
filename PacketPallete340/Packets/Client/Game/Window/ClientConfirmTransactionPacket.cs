using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Protocol.Helpres;

namespace PacketPallete340.Packets.Client.Game.Window
{

    [PacketMeta(0x05, 340, PacketSide.Client, PacketCategory.Game)]
    public class ClientConfirmTransactionPacket : ClientPacket
    {
        //out.writeByte(this.windowId);
       //out.writeShort(this.actionId);
       //out.writeBoolean(this.accepted);
        public override void Write(MinecraftStream output)
        {
            
        }
    }
}