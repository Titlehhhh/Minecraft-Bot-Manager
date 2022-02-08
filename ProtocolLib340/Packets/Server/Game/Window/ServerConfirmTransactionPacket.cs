using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Protocol.Helpres;

namespace ProtocolLib340.Packets.Server.Game.Window
{

    [PacketMeta(0x11, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerConfirmTransactionPacket : MinecraftPacket
    {
        //this.windowId = in.readUnsignedByte();
       //this.actionId = in.readShort();
       //this.accepted = in.readBoolean();
        public override void Read(IMinecraftStreamReader input)
        {
            
        }
        public ServerConfirmTransactionPacket() {}
    }

}
