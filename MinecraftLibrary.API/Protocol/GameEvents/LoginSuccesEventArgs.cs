namespace MinecraftLibrary.API.Protocol
{
    public class LoginSuccesEventArgs : EventArgs
    {
        public string Nickname { get; private set; }
        public Guid UUID { get; private set; }
    }
}
