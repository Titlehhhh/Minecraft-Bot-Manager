using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Client.Game
{

    [PacketInfo(0x02, 340, PacketSide.Client, PacketCategory.Game)]
    public class ClientChatPacket : MinecraftPacket
    {
        public string Message { get; set; }
        
        public override void Write(IMinecraftStreamWriter output)
        {
            output.WriteString(Message);
        }

        public ClientChatPacket(string message)
        {
            Message = message;
        }
    }
}
