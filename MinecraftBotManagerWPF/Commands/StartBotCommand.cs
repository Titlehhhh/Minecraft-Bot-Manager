using MinecraftLibrary;
using System;
using System.Threading.Tasks;

namespace MinecraftBotManagerWPF
{
    internal class StartBotCommand : AsyncCommandBase
    {

        private readonly MinecraftClientInizializer inizializer;
        private readonly BotViewModel _botViewModel;


        public StartBotCommand(MinecraftClientInizializer inizializer)
        {
            this.inizializer = inizializer;
            this._botViewModel = inizializer.BotViewModel;
        }

        public async override Task ExecuteAsync(object parameter)
        {
            MinecraftClient client = this.inizializer.CreateBot();
            try
            {
                await client.StartAsync();
            }
            catch (Exception e)
            {
                _botViewModel.BotState = State.None;
            }

        }
    }
}
