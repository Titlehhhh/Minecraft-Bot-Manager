namespace MinecraftBotManager.API
{



    public delegate void AddBotHandler(IBot newbot);
    public interface IBotRepository
    {
        Task InizializeAsync();

        Task AddBot(IBot bot);
        Task RemoveBot(IBot bot);
       Task SaveAsync();

        IEnumerable<IBot> GetAllBots();

        event AddBotHandler AddBotEvent;
    }
}
