using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml.Media.Imaging;
using MinecraftBotManager.Api.Models;
using MinecraftBotManager.Data;
using MinecraftBotManager.Helpers;

using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;


namespace MinecraftBotManager.ViewModels
{
    public sealed partial class BotViewModel : NotificationBase<BotInfo>, IDisposable
    {
        private readonly BotRunService botRunService;




        public BotViewModel(BotInfo bot, IAsyncRelayCommand deletecommand) : base(bot)
        {
            this.DeleteCommand = deletecommand;
            botRunService = new BotRunService(this, bot);

        }

        #region Commands
        [ICommand]
        private async Task StartBot()
        {
            await botRunService.StartBot();
        }

        [ICommand]
        private async Task StopBot()
        {

        }



        public IAsyncRelayCommand DeleteCommand { get; private set; }

        #endregion

        #region Properties

        [ObservableProperty]
        private bool imgaeLoading;


        private BitmapImage icon;

        public BitmapImage Icon
        {
            get => icon;
            set => SetProperty(ref icon, value);
        }




        public string Username
        {
            get
            {
                return This.Username;
            }
            set => SetProperty(This.Username, value, (v) => This.Username = v);

        }

        public string Server
        {
            get => This.Server;
            set => SetProperty(This.Server, value, (v) => This.Server = v);
        }


        public int Version
        {
            get => This.ProtocolVersion;
            set => SetProperty(This.ProtocolVersion, value, (v) => This.ProtocolVersion = v);
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



        public TypeProxy ProxyType
        {
            get => This.ProxyType;
            set => SetProperty(This.ProxyType, value, (v) => This.ProxyType = v);
        }
        public bool IsEnabledProxyControls => ProxyEnabled && !OptimaleProxy;

        public ObservableCollection<string> LocalIps { get; } = new();


        #endregion

        #region Errors
        public StatusVM VersionStatus { get; private set; } = new();
        public StatusVM ServerStatus { get; private set; } = new();
        public StatusVM AuthStatus { get; private set; } = new();
        public StatusVM ProxyStatus { get; private set; } = new();

        [ObservableProperty]
        private string nickError;
        [ObservableProperty]
        private string serverError;
        [ObservableProperty]
        private string passwordError;
        [ObservableProperty]
        private string proxyAddressError;
        [ObservableProperty]
        private string proxyLoginError;
        [ObservableProperty]
        private string proxyPasswordError;

        public void AllErrorsClear()
        {
            NickError = "";
            ServerError = "";
            PasswordError = "";
            ProxyAddressError = "";
            ProxyLoginError = "";
            proxyPasswordError = "";
        }

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
