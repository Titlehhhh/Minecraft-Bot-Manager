using System.Threading.Tasks;

namespace MinecraftBotManagerWPF
{
    public class AddBotCommand : AsyncCommandBase
    {
        private readonly IBotVMFactory botVMFactory;
        private readonly BotViewModelsStorage botViewModels;
        private readonly IBotRepository botRepository;

        public AddBotCommand(IBotVMFactory botVMFactory, BotViewModelsStorage botViewModels, IBotRepository botRepository)
        {
            this.botVMFactory = botVMFactory;
            this.botViewModels = botViewModels;
            this.botRepository = botRepository;
        }




        public override async Task ExecuteAsync(object parameter)
        {
            BotInfo bot = new BotInfo();
            BotViewModel botViewModel = botVMFactory.Create(bot);
            //  new BotViewModel(bot);

            await botRepository.AddBot(bot);

            botViewModels.Bots.Add(botViewModel);

            botViewModels.CurrentBot = botViewModel;
        }
    }
}
