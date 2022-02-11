using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Client.Game
{

    [PacketInfo(0x02, 340, PacketSide.Client, PacketCategory.Game)]
    public class ClientChatPacket : IPacket
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
