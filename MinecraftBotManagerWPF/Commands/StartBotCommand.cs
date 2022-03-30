using MinecraftLibrary;
using System;
using System.Threading.Tasks;
using System.Diagnostics;
using MinecraftLibrary.Exceptions;

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
            _botViewModel.RefreshPropertis();
            _botViewModel.BotState = State.Initialized;

            MinecraftClient754 client = this.inizializer.CreateBot();
            try
            {
                await client.LoginAsync();
                _botViewModel.BotState = State.Running;
            }
            catch (LoginRejectException e)
            {
                
                _botViewModel.BotState = State.None;
            }
            catch(Exception e)
            {
                System.Windows.MessageBox.Show(e.ToString());
                _botViewModel.BotState = State.None;
            }

        }
    }
}
