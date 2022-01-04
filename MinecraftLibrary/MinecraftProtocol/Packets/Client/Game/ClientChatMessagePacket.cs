using MinecraftProtocol.IO;
using MinecraftProtocol.Packets;

namespace MinecraftLibrary.MinecraftProtocol.Packets.Client.Game
{
    public class ClientChatMessagePacket : ClientPacket
    {

        public string Message { get; set; }
        public void Write(NetOutput output, int version)
        {
            if(!string.IsNullOrEmpty(Message))
           output.WriteString(Message);
        }

        public ClientChatMessagePacket(string message)
        {
            Message = message;
        }
        public ClientChatMessagePacket()
        {

        }
    }



}
