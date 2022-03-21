namespace MinecraftLibrary.API.Protocol
{
    public class DisconnectedEventArgs : EventArgs
    {
        public Exception Exception { get; private set; }
        public string Message { get; private set; }
        public DisconnectReason Reason { get; private set; }

        public DisconnectedEventArgs(string message, DisconnectReason reason, Exception exception = null)
        {
            Message = message;
            Reason = reason;
            Exception = exception;
        }
    }
}
