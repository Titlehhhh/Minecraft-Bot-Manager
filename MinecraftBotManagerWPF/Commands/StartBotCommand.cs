using MinecraftLibrary;
using System;
using System.Threading.Tasks;
using System.Diagnostics;

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
            
            MinecraftClient754 client = this.inizializer.CreateBot();
            try
            {
                await client.StartAsync();
            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show(e.ToString());
                _botViewModel.BotState = State.None;
            }

        }
    }
}
