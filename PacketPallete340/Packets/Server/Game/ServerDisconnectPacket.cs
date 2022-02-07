using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Protocol.Helpres;

namespace PacketPallete340.Packets.Server.Game
{

    [PacketMeta(0x1A, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerDisconnectPacket : MinecraftPacket
    {
        //this.message = Message.fromString(in.readString());
        public override void Read(IMinecraftStreamReader input)
        {
            
        }
        public ServerDisconnectPacket() {}
    }

}
