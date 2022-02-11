using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Server.Game.Window
{

    [PacketInfo(0x11, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerConfirmTransactionPacket : IPacket
    {
        //this.windowId = in.readUnsignedByte();
       //this.actionId = in.readShort();
       //this.accepted = in.readBoolean();
        public void Read(MinecraftStream stream)
        {
            
        }

        public void Write(MinecraftStream stream)
        {
            
        }

        public ServerConfirmTransactionPacket() {}
    }

}
