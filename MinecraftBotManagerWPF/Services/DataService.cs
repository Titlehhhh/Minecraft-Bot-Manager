namespace MinecraftBotManagerWPF
{
    public class DataService : IDataService
    {
        private readonly IBotRepository botRepository;

        public DataService(IBotRepository botRepository)
        {
            this.botRepository = botRepository;
        }
        public IBotRepository BotRepository => botRepository;

        public void Save()
        {
            BotRepository.SaveAsync();
        }
    }
}
