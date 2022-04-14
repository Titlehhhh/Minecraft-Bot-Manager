using MinecraftLibrary;
using MinecraftLibrary.Exceptions;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace MinecraftBotManagerWPF
{
    internal class StartBotCommand : AsyncCommandBase
    {
        private readonly IBotRepository botRepository;
        private readonly BotViewModel _botViewModel;

        public StartBotCommand(BotViewModel botViewModel, IBotRepository botRepository)
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

                MinecraftBot bot = new MinecraftBot();

                MinecraftClient client = bot.Client;

                _botViewModel.Client = client;

                bot.MessageReceived += (m) =>
                {
                    Application.Current.Dispatcher.Invoke(() => _botViewModel.Messages.Add(m));
                };

                await client.LoginAsync();

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
