namespace MinecraftBotManagerWPF
{
    public delegate void AddBotHandler(BotInfo newbot);
    public interface IDataService
    {
        IBotRepository BotRepository { get; }
        void Save();
    }
}
