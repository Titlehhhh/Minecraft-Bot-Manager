using System.Threading.Tasks;
using System;

namespace MinecraftBotManagerWPF
{
    internal class StopBotCommand : AsyncCommandBase
    {

        private readonly MinecraftClientInizializer inizializer;
        private readonly BotViewModel _botViewModel;

        public StopBotCommand(MinecraftClientInizializer inizializer)
        {
            this.inizializer = inizializer;
            this._botViewModel = inizializer.BotViewModel;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                
                if(_botViewModel.Client == null)
                return;
                if (_botViewModel.BotState == State.None)
                    return;

                _botViewModel.Client.Disconnect();
                //_botViewModel.Client.Dispose();
                //_botViewModel.Client.Dispose();
                //_botViewModel.Client = null;

                _botViewModel.BotState = State.None;

            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show(e.ToString());
            }
        }
    }
}
