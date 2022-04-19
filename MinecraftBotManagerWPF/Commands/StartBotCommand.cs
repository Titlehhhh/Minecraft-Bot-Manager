using MinecraftLibrary;
using MinecraftLibrary.API;
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
        private readonly IAuthService _authService;

        public StartBotCommand(BotViewModel botViewModel, IBotRepository botRepository, IAuthService authService)
        {
            this._botViewModel = botViewModel;
            this.botRepository = botRepository;
            this._authService = authService;
        }

        public async override Task ExecuteAsync(object parameter)
        {
            await this.botRepository.SaveAsync();
            _botViewModel.ReturnToOrgignalStateStatuses();
            _botViewModel.RefreshPropertis();
            _botViewModel.BotState = State.Initialized;

            MinecraftBotBuilder builder = MinecraftBotBuilder.Create();

            BotInfo info = _botViewModel.BotInfoModel;

            if (_botViewModel.AuthEnabled)
            {
                _botViewModel.AuthStatus.Status = StatusCheck.Init;
                _botViewModel.AuthStatus.Message = "Авторизация";

                GameProfile gameProfile = null;
                AuthInfo authInfo = new AuthInfo(info.AccType, info.Nickname, info.Password);
                LoginResult result = await _authService.AuthAsync(authInfo, out gameProfile);

                string message = "";
                StatusCheck status = default;
                switch (result)
                {
                    case LoginResult.Success:
                        status = StatusCheck.Ok;
                        message = "Авторизация успешна!";
                        break;
                    default:
                        status = StatusCheck.Error;
                        message = result.ToString();
                        return;                        
                }
                _botViewModel.AuthStatus.Status = status;
                _botViewModel.AuthStatus.Message = message;

                builder.SetProfile(gameProfile);
            }

            if (info.ProxyEnabled)
            {
                if (string.IsNullOrEmpty(info.ProxyHost))
                {

                }
                _botViewModel.ProxyStatus.Status = StatusCheck.Init;
                
                if (info.AutoFindProxyEnabled)
                {
                    _botViewModel.ProxyStatus.Message = "Поиск оптимального прокси";

                }

                _botViewModel.ProxyStatus.Message = "Проверка прокси";

            }

            _botViewModel.ServerStatus.Status = StatusCheck.Init;
            _botViewModel.ServerStatus.Message = "Определение SRV";


            try
            {



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
