using MinecraftLibrary.API;
using MinecraftLibrary.Services;
using System.Threading.Tasks;

namespace MinecraftBotManagerWPF
{
    public class AddBotCommand : AsyncCommandBase
    {
        private readonly IBotRepository botRepository;
        private readonly IAuthService authService;
        private readonly IServerResolver resolver;
        private readonly BotViewModelsStorage botViewModels;

        public AddBotCommand(BotViewModelsStorage botViewModels, IBotRepository botRepository, IAuthService authService, IServerResolver resolver)
        {
            this.botRepository = botRepository;
            this.botViewModels = botViewModels;
            this.authService = authService;
            this.resolver = resolver;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            BotInfo bot = new BotInfo();
            BotViewModel botViewModel = new BotViewModel(bot, this.botRepository, resolver, authService);
            //  new BotViewModel(bot);

            await botRepository.AddBot(bot);

            botViewModels.Bots.Add(botViewModel);

            botViewModels.CurrentBot = botViewModel;
        }
    }
}
