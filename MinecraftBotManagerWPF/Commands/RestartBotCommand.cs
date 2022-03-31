using System.Threading.Tasks;
using System;
using MinecraftLibrary;

namespace MinecraftBotManagerWPF
{
    internal class RestartBotCommand : AsyncCommandBase
    {
        private readonly BotVMHelper inizializer;
        private readonly BotViewModel _botViewModel;

        public RestartBotCommand(BotVMHelper inizializer)
        {
            this.inizializer = inizializer;
            this._botViewModel = inizializer.BotViewModel;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                if (_botViewModel.Client == null)
                    return;
                if (_botViewModel.BotState != State.Running)
                    return;

                


            }
            catch (Exception)
            {
                _botViewModel.BotState = State.None;

            }
        }
    }
}
