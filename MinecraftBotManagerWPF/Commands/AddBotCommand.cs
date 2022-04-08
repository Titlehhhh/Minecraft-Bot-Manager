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
            BotInfo bot = new BotInfo();
            BotViewModel botViewModel = new BotViewModel(bot, this.botRepository);
            //  new BotViewModel(bot);

            await botRepository.AddBot(bot);

            botViewModels.Bots.Add(botViewModel);

            botViewModels.CurrentBot = botViewModel;
        }
    }
}
