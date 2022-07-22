using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml.Media.Imaging;
using MinecraftBotManager.Core;
using MinecraftBotManager.Core.Data;
using MinecraftBotManager.Core.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace MinecraftBotManager.ViewModels
{
    public sealed class Logger : ILogger
    {
        public void Error(string message)
        {
            //throw new NotImplementedException();
        }

        public void Info(string message)
        {
           // throw new NotImplementedException();
        }

        public void Warn(string message)
        {
          //  throw new NotImplementedException();
        }
    }
    public sealed class NotEmpty : ValidationAttribute
    {
        private readonly string propName;
        public NotEmpty(string propName = "")
        {
            this.propName = propName;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string v = (string)value;

            if (string.IsNullOrEmpty(v))
                return new("Введите ник");
            return ValidationResult.Success;
        }
    }

    public sealed partial class BotViewModel : NotificationBase<ConnectionSettings>, IDisposable, IBotObserver
    {


        private readonly IBot _bot = new Bot(new Logger());


        public BotViewModel(ConnectionSettings bot, IAsyncRelayCommand deletecommand) : base(bot)
        {

            _bot.AddObserver(this);
            this.DeleteCommand = deletecommand;


        }



        #region Commands
        [ICommand]
        private async Task StartBot()
        {
             _bot.Start((ConnectionSettings)This.Clone());
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



        [NotEmpty]
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
            ProxyPasswordError = "";
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
        public bool Validate()
        {
            AllErrorsClear();

            bool ok = true;
            if (string.IsNullOrEmpty(Username))
            {
                NickError = "Введите ник";
                ok = false;
            }
            if (string.IsNullOrEmpty(Server))
            {
                ServerError = "Введите адрес";
                ok = false;
            }
            if (AuthEnabled)
            {
                if (string.IsNullOrEmpty(Password))
                {
                    PasswordError = "Введите пароль";
                    ok = false;
                }
            }
            if (ProxyEnabled && IsEnabledProxyControls)
            {
                if (string.IsNullOrEmpty(ProxyAddress))
                {
                    ProxyAddressError = "Введите адрес";
                    ok = false;
                }
                bool a, b = true;
                if (!((a = string.IsNullOrEmpty(ProxyLogin)) && (b = string.IsNullOrEmpty(ProxyPass))))
                {
                    if (a)
                    {
                        ProxyLoginError = "Введите значение";
                    }
                    if (b)
                    {
                        ProxyPasswordError = "Введите пароль";
                    }
                    ok = false;
                }
            }
            return ok;
        }


        public void Dispose()
        {

        }



        // public StatusVM ServerStatus { get; private set; } = new();
        #endregion

        #region Observer
        public void OnError(Exception e)
        {

        }

        public void OnCompleted()
        {

        }

        public void OnConnecting()
        {
            ServerStatus.Load("Подключено");
        }

        public void OnConnected()
        {
            ServerStatus.Load("Подключение...");
        }

        public void OnDisconnected()
        {

        }

        public void OnFindQuickProxy()
        {
            ProxyStatus.Load("Подбор оптимального сервера...");
        }

        public void OnProxyConnecting()
        {
            ProxyStatus.Load("Подключение...");
        }

        public void OnProxyConnected()
        {
            ProxyStatus.Ok("Подключено");
        }

        public void OnAuthentification()
        {
            ServerStatus.Load("Аутентификатция");
        }

        public void SrvFinding()
        {
            ServerStatus.Load("Получение SRV...");
        }

        public void SrvFinded(string address)
        {

        }


        #endregion


    }




}
