using MinecraftLibrary.API.Networking;

namespace MinecraftLibrary.API
{
    public class ProtocolClientDisconnectEventArg : DisconnectedEventArgs
    {
        public ProtocolClientDisconnectEventArg(string message, Exception exception = null, DisconnectReason reason = DisconnectReason.ConnectionLost) : base(message, exception)
        {
            Reason = reason;
        }

        public DisconnectReason Reason { get; private set; }

    }
}
