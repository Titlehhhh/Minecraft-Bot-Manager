using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Client.Game.Window
{

    [PacketInfo(0x05, 340, PacketSide.Client, PacketCategory.Game)]
    public class ClientConfirmTransactionPacket : MinecraftPacket
    {
        //out.writeByte(this.windowId);
       //out.writeShort(this.actionId);
       //out.writeBoolean(this.accepted);
        public override void Write(IMinecraftStreamWriter output)
        {
            
        }
    }
}
