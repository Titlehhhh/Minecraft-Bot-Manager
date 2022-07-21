namespace MinecraftBotManager.Core.Exceptions
{
    public sealed class ValidationException : Exception
    {
        public IReadOnlyDictionary<string, string> Errors { get; private set; }

        public ValidationException(IReadOnlyDictionary<string, string> errors)
        {
            this.Errors = errors;
        }
    }
}
