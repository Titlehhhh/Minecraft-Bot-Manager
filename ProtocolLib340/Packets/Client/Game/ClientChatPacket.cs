using MinecraftLibrary.API.Networking;

using MinecraftLibrary.API.IO;

namespace ProtocolLib340.Packets.Client.Game
{

    
    public class ClientChatPacket : IPacket
    {
        public string Message { get; set; }
        
        public void Write(IMinecraftStreamWriter stream)
        {
            stream.WriteString(Message);
        }

        public void Read(IMinecraftStreamReader stream)
        {
            
        }

        public ClientChatPacket(string message)
        {
            Message = message;
        }
    }
}
