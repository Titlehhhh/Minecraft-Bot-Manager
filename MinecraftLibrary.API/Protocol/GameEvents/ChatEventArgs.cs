using MinecraftLibrary.API.Types.Chat;

namespace MinecraftLibrary.API.Protocol
{
    public class ChatEventArgs : EventArgs
    {
        public ChatMessage Message { get; private set; }

        public ChatEventArgs(ChatMessage message)
        {
            Message = message;
        }
    }
}
