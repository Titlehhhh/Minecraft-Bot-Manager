namespace MinecraftBotManagerWPF
{
    public delegate void AddBotHandler(Bot newbot);
    public interface IDataService
    {
        IBotRepository BotRepository { get; }
        void Save();
    }
}
