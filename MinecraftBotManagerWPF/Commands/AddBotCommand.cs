using System.Threading.Tasks;

namespace MinecraftBotManagerWPF
{
    public class AddBotCommand : AsyncCommandBase
    {
        private readonly IBotRepository botRepository;
        private readonly BotViewModelsStorage botViewModels;
        private readonly MinecraftBotFactory factory;

        public AddBotCommand(BotViewModelsStorage botViewModels, IBotRepository botRepository)
        {
            this.botRepository = botRepository;
            this.botViewModels = botViewModels;
            this.factory = factory;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            BotInfo bot = new BotInfo();
            BotViewModel botViewModel = new BotViewModel(bot);
            //  new BotViewModel(bot);

            await botRepository.AddBot(bot);

            botViewModels.Bots.Add(botViewModel);

            botViewModels.CurrentBot = botViewModel;
        }
    }
}
