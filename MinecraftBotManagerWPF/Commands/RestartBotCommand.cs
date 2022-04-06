using System.Threading.Tasks;
using System;
using MinecraftLibrary;

namespace MinecraftBotManagerWPF
{
    internal class RestartBotCommand : AsyncCommandBase
    {
        private readonly BotViewModel _botViewModel;

        public RestartBotCommand(BotViewModel botViewModel)
        {
            this._botViewModel = botViewModel;
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
