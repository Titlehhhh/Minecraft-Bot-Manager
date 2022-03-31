using MinecraftLibrary;
using System;
using System.Threading.Tasks;
using System.Diagnostics;
using MinecraftLibrary.Exceptions;

namespace MinecraftBotManagerWPF
{
    internal class StartBotCommand : AsyncCommandBase
    {
        private readonly IBotRepository botRepository;
        private readonly BotViewModel _botViewModel;

        public StartBotCommand(BotViewModel botViewModel,IBotRepository botRepository)
        {
            this._botViewModel = botViewModel;
            this.botRepository = botRepository;
        }

        public async override Task ExecuteAsync(object parameter)
        {
            await this.botRepository.SaveAsync();

            _botViewModel.RefreshPropertis();
            _botViewModel.BotState = State.Initialized;
            try
            {
                
                _botViewModel.BotState = State.Running;
            }
            catch (LoginRejectException e)
            {

                _botViewModel.BotState = State.None;
            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show(e.ToString());
                _botViewModel.BotState = State.None;
            }

        }
    }
}
