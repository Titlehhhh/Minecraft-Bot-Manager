using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Protocol.Helpres;

namespace PacketPallete340.Packets.Client.Game
{

    [PacketMeta(0x02, 340, PacketSide.Client, PacketCategory.Game)]
    public class ClientChatPacket : ClientPacket
    {
        public string Message { get; set; }
        
        public override void Write(MinecraftStream output)
        {
            output.WriteString(Message);
        }

        public ClientChatPacket(string message)
        {
            Message = message;
        }
    }
}
