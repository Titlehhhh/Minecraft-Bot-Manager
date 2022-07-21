namespace MinecraftBotManager.Core.Exceptions
{
    public sealed class AuthentificationException : Exception
    {
        public AuthentificationError Error { get; private set; }

        public AuthentificationException(AuthentificationError error)
        {
            Error = error;
        }
    }
}
