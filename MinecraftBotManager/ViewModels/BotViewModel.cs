using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml.Media.Imaging;
using MinecraftBotManager.Api.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;


namespace MinecraftBotManager.ViewModels
{
    [ObservableObject]
    public sealed partial class BotViewModel
    {




        #region Commands
        [ICommand]
        private async Task StartBot()
        {

            AllStatusesDisabled();

            if (OptimaleProxy)
            {
                ProxyStatus.Load("Поиск оптимального прокси");
                await Task.Delay(5000);
                ProxyStatus.Ok("Сервер найден: 123.456.7.8:8080\nТип: Http");
            }



            VersionStatus.Load();

            ServerStatus.Load("Получение информации о сервере...");
            await Task.Delay(5000);

            VersionStatus.Warn("Версия не соотвествует версии сервера");

            ServerStatus.Load("Подключение...");
            await Task.Delay(1000);
            ServerStatus.Load("Рукопожатие");
            await Task.Delay(1000);
            ServerStatus.Load("Включение сжатия...");
            await Task.Delay(1000);

            ServerStatus.Ok("Подключено");
        }



        private RelayCommand stopBotCommand;
        public RelayCommand StopBotCommand
        {
            get => stopBotCommand ?? (stopBotCommand = new RelayCommand(() =>
            {

            }));
        }

        private RelayCommand deleteCommand;
        public RelayCommand DeleteCommand
        {
            get => deleteCommand ?? (deleteCommand = new RelayCommand(() =>
            {

            }));
        }

        #endregion

        #region Properties

        private BitmapImage icon;

        public BitmapImage Icon
        {
            get { return icon; }
            private set
            {
                icon = value;
                OnPropertyChanged();
            }
        }



        public string Username
        {
            get => bot.Username;
            set { bot.Username = value; }
        }

        private string host;

        public string Host
        {
            get => host;
            set
            {

                SetProperty(ref host, value);
            }

        }

        #region Auth



        private string password;

        public string Password
        {
            get => password;
            set => SetProperty(ref password, value);
        }


        private bool authEnabled;

        public bool AuthEnabled
        {
            get => authEnabled;
            set { SetProperty(ref authEnabled, value); System.Diagnostics.Trace.WriteLine(13); }
        }
        #endregion


        private string version;

        public string Version
        {
            get => version;
            set => SetProperty(ref version, value);
        }

        #region Proxy
        private bool proxyEnabled;

        public bool ProxyEnabled
        {
            get => proxyEnabled;
            set
            {
                SetProperty(ref proxyEnabled, value);
                OnPropertyChanged(nameof(IsEnabledProxyControls));
            }
        }

        private string proxyHost;

        public string ProxyAdress
        {
            get => proxyHost;
            set => SetProperty(ref proxyHost, value);
        }

        private string proxylogin;

        public string ProxyLogin
        {
            get => proxylogin;
            set => SetProperty(ref proxylogin, value);
        }


        private string proxypass;

        public string ProxyPass
        {
            get => proxypass;
            set => SetProperty(ref proxypass, value);
        }

        private bool optiproxy;

        public bool OptimaleProxy
        {
            get => optiproxy;
            set
            {
                SetProperty(ref optiproxy, value);
                OnPropertyChanged(nameof(IsEnabledProxyControls));
            }
        }

        public bool IsEnabledProxyControls => ProxyEnabled && !OptimaleProxy;
        #endregion








        public ObservableCollection<string> LocalIps { get; } = new();

        public ObservableCollection<string> ProxyTypes { get; } = new()
        {
            "Http",
            "Socks4",
            "Socks5"
        };

        #endregion

        #region Errors
        public StatusVM VersionStatus { get; private set; } = new();
        public StatusVM ServerStatus { get; private set; } = new();
        public StatusVM AuthStatus { get; private set; } = new();
        public StatusVM ProxyStatus { get; private set; } = new();

        public void AllStatusesLoad()
        {
            VersionStatus.Load();
            ServerStatus.Load();
            AuthStatus.Load();
            ProxyStatus.Load();
        }
        public void AllStatusesDisabled()
        {
            VersionStatus.Disabled();
            ServerStatus.Disabled();
            AuthStatus.Disabled();
            ProxyStatus.Disabled();
        }
        // public StatusVM ServerStatus { get; private set; } = new();
        #endregion

        private Bot bot;

        public BotViewModel(Bot bot)
        {
            LocalIps.Add("asdasd");
            this.bot = bot;
            bot.PropertyChanged += (s, e) =>
            {
                OnPropertyChanged(e.PropertyName);
            };
        }


    }

}
