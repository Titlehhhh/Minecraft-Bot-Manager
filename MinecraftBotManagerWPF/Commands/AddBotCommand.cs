using System.Threading.Tasks;

namespace MinecraftBotManagerWPF
{
    public class AddBotCommand : AsyncCommandBase
    {
        private readonly IBotRepository botRepository;
        private readonly BotViewModelsStorage botViewModels;

        public AddBotCommand(BotViewModelsStorage botViewModels, IBotRepository botRepository)
        {
            this.botRepository = botRepository;
            this.botViewModels = botViewModels;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            MinecraftBot bot = new MinecraftBot();
            BotViewModel botViewModel = null;
            //  new BotViewModel(bot);

            await botRepository.AddBot(bot);

            botViewModels.Bots.Add(botViewModel);

            botViewModels.CurrentBot = botViewModel;
        }
    }
}
