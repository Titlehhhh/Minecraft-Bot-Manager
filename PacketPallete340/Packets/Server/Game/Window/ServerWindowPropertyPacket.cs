using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Protocol.Helpres;

namespace PacketPallete340.Packets.Server.Game.Window
{

    [PacketMeta(0x15, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerWindowPropertyPacket : MinecraftPacket
    {
        //this.windowId = in.readUnsignedByte();
       //this.property = in.readShort();
       //this.value = in.readShort();
        public override void Read(IMinecraftStreamReader input)
        {
            
        }
        public ServerWindowPropertyPacket() {}
    }

}
