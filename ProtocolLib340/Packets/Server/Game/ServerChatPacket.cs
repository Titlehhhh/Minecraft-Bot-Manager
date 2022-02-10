using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Server.Game
{

    [PacketInfo(0x0F, 340, PacketSide.Server, PacketCategory.Game)]
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
