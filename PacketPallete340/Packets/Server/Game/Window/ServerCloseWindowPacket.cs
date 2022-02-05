using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Protocol.Helpres;

namespace PacketPallete340.Packets.Server.Game.Window
{

    [PacketMeta(0x12, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerCloseWindowPacket : MinecraftPacket
    {
        //this.windowId = in.readUnsignedByte();
        public override void Read(MinecraftStream output)
        {
            
        }
        public ServerCloseWindowPacket() {}
    }

}