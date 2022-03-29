using System.Threading.Tasks;
using System;
using MinecraftLibrary;

namespace MinecraftBotManagerWPF
{
    internal class RestartBotCommand : AsyncCommandBase
    {
        private readonly MinecraftClientInizializer inizializer;
        private readonly BotViewModel _botViewModel;

        public RestartBotCommand(MinecraftClientInizializer inizializer)
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
                if (_botViewModel.BotState != State.Running)
                    return;

                    _botViewModel.BotState = State.None;
                    _botViewModel.Client.Disconnect();
                    //_botViewModel.Client.Dispose();

                    MinecraftClient client = this.inizializer.CreateBot();

                    await client.StartAsync();

                
            }
            catch (Exception e)
            {
                _botViewModel.BotState = State.None;

            }
        }
    }
}
