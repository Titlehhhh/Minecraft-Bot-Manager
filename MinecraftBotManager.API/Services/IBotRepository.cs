namespace MinecraftBotManager.Core
{



    public delegate void AddBotHandler(Bot newbot);
    public interface IBotRepository
    {
        Task InizializeAsync();

        Task AddBot(Bot bot);
        Task RemoveBot(Bot bot);
       Task SaveAsync();

        IEnumerable<Bot> GetAllBots();

        event AddBotHandler AddBotEvent;
    }
}
