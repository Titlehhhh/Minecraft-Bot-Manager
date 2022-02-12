using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Client.Game
{

    [PacketHeader(0x02, 340, PacketSide.Client, PacketCategory.Game)]
    public class ClientChatPacket : IPacket
    {
        public string Message { get; set; }
        
        public void Write(MinecraftStream stream)
        {
            stream.WriteString(Message);
        }

        public void Read(MinecraftStream stream)
        {
            
        }

        public ClientChatPacket(string message)
        {
            Message = message;
        }
    }
}
