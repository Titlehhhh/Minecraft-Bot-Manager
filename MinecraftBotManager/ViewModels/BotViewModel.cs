using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml.Media.Imaging;
using MinecraftBotManager.Api.Models;
using MinecraftBotManager.Data;
using MinecraftBotManager.Helpers;
using Starksoft.Net.Proxy;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;


namespace MinecraftBotManager.ViewModels
{
    public sealed partial class BotViewModel : NotificationBase<BotRecord>, IDisposable
    {
        private readonly BotRunService botRunService;




        public BotViewModel(BotRecord bot, IAsyncRelayCommand deletecommand) : base(bot)
        {
            this.DeleteCommand = deletecommand;
            botRunService = new BotRunService(bot, this);
        }

        #region Commands
        [ICommand]
        private async Task StartBot()
        {
            await botRunService.StartBot();
        }



        public IAsyncRelayCommand DeleteCommand { get; private set; }

        #endregion

        #region Properties

        [ObservableProperty]
        private bool imgaeLoading;


        public BitmapImage Icon
        {
            get => This.Icon;
            set => SetProperty(This.Icon, value, (v) => This.Icon = v);
        }



        public string Username
        {
            get
            {
                if (string.IsNullOrWhiteSpace(This.Username))
                {
                    return "Новый бот";
                }
                return This.Username;
            }
            set => SetProperty(This.Username, value, (v) => This.Username = v);

        }


        public string Version
        {
            get => This.Version;
            set => SetProperty(This.Version, value, (v) => This.Version = v);
        }


        public bool ProxyEnabled
        {
            get => This.ProxyEnabled;
            set
            {
                SetProperty(This.ProxyEnabled, value, (v) => This.ProxyEnabled = v);
                OnPropertyChanged(nameof(IsEnabledProxyControls));
            }
        }


        public bool OptimaleProxy
        {
            get => This.OptimaleProxy;
            set
            {
                SetProperty(This.OptimaleProxy, value, (v) => This.OptimaleProxy = v);
                OnPropertyChanged(nameof(IsEnabledProxyControls));
            }
        }


        public string Password
        {
            get => This.Password;
            set => SetProperty(This.Password, value, (v) => This.Password = v);
        }


        public bool AuthEnabled
        {
            get => This.AuthEnabled;
            set => SetProperty(This.AuthEnabled, value, (v) => This.AuthEnabled = v);
        }


        public string ProxyAddress
        {
            get => This.ProxyAddress;
            set => SetProperty(This.ProxyAddress, value, (v) => This.ProxyAddress = v);
        }


        public string ProxyLogin
        {
            get => This.ProxyLogin;
            set => SetProperty(This.ProxyLogin, value, (v) => This.ProxyLogin = v);
        }


        public string ProxyPass
        {
            get => This.ProxyPass;
            set => SetProperty(This.ProxyPass, value, (v) => This.ProxyPass = v);
        }


        public string ProxyType
        {
            get => This.ProxyType.ToString();
            set
            {
                try
                {
                    ProxyType pt = (ProxyType)Enum.Parse(typeof(ProxyType), value);

                    This.ProxyType = pt;
                    OnPropertyChanged();
                }
                catch
                {

                }
            }
        }



        public bool IsEnabledProxyControls => ProxyEnabled && !OptimaleProxy;

        public ObservableCollection<string> LocalIps { get; } = new();

        public ObservableCollection<string> ProxyTypes { get; } = new()
        {
            "Http",
            "Socks4",
            "Socks4a",
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

        public void Dispose()
        {

        }

        // public StatusVM ServerStatus { get; private set; } = new();
        #endregion




    }

}
