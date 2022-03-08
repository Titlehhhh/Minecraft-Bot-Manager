using MinecraftBotManagerWPF.Interfaces;

namespace MinecraftBotManagerWPF.Services
{
    public class DataService : IDataService
    {
        private readonly IBotRepository botRepository = new BotRepository();

        public DataService()
        {

        }
        public IBotRepository BotRepository => botRepository;

        public void Save()
        {
            BotRepository.Save();
        }
    }
}
