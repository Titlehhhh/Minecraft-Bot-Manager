using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Protocol.Helpres;

namespace PacketPallete340.Packets.Server.Game
{

    [PacketMeta(0x4A, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerPlayerListDataPacket : MinecraftPacket
    {
        //this.header = Message.fromString(in.readString());
       //this.footer = Message.fromString(in.readString());
        public override void Read(IMinecraftStreamReader input)
        {
            
        }
        public ServerPlayerListDataPacket() {}
    }

}
