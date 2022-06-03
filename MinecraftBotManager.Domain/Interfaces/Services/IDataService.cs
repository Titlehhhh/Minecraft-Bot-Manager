namespace MinecraftBotManagerWPF
{

    public interface IDataService
    {
        IBotRepository BotRepository { get; }
        void Save();
    }
}
