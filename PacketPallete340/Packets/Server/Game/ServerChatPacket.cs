using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Protocol.Helpres;

namespace PacketPallete340.Packets.Server.Game
{

    [PacketMeta(0x0F, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerChatPacket : MinecraftPacket
    {
        //this.message = Message.fromString(in.readString());
       //this.type = MagicValues.key(MessageType.class, in.readByte());
        public override void Read(IMinecraftStreamReader input)
        {
            
        }
        public ServerChatPacket() {}
    }

}
