namespace MinecraftBotManagerWPF
{
    public delegate void AddBotHandler(MinecraftBot newbot);
    public interface IDataService
    {
        IBotRepository BotRepository { get; }
        void Save();
    }
}
