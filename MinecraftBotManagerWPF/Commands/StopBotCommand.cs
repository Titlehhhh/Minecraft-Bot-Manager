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
                await _botViewModel.Client.StopAsync();
                _botViewModel.Client.Dispose();

            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show(e.ToString());
            }
            finally
            {
                _botViewModel.BotState = State.None;
            }


        }
    }
}
