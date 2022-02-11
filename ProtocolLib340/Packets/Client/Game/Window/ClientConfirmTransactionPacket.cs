using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Client.Game.Window
{

    [PacketInfo(0x05, 340, PacketSide.Client, PacketCategory.Game)]
    public class ClientConfirmTransactionPacket : IPacket
    {
        public void Read(MinecraftStream stream)
        {
            
        }

        //out.writeByte(this.windowId);
        //out.writeShort(this.actionId);
        //out.WriteBooleanean(this.accepted);
        public void Write(MinecraftStream stream)
        {
            
        }
    }
}
