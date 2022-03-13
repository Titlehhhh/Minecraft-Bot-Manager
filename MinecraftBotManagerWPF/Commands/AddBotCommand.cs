using System;
using System.Threading.Tasks;
using System.Windows.Input;

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
            Bot bot = new Bot();
            BotViewModel botViewModel = new BotViewModel(bot);

            await botRepository.AddBot(bot);

            botViewModels.Bots.Add(botViewModel);

            botViewModels.CurrentBot = botViewModel;
        }
    }
}
