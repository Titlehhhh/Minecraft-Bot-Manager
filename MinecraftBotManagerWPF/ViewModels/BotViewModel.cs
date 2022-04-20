using Microsoft.Toolkit.Mvvm.Input;
using MinecraftLibrary;
using MinecraftLibrary.API;
using MinecraftLibrary.API.Types.Chat;
using MinecraftLibrary.Geometry;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MinecraftBotManagerWPF
{
    public class BotViewModel : ViewModelBase
    {
        internal MinecraftClient Client { get; set; }

        public BotInfo BotInfoModel => botInfo;



        private readonly BotInfo botInfo;
        private readonly IBotRepository _botRepository;

        public BotViewModel(BotInfo botInfo, IBotRepository botRepository, IServerResolver resolver, IAuthService authService)
        {
            if (botInfo is null)
                throw new ArgumentNullException(nameof(botInfo));
            this.botInfo = botInfo;
            this._botRepository = botRepository;
            //botInfo.Proxy = new MinecraftLibrary.API.Networking.Proxy.ProxyInfo();
            //  botInfo.Auth = new AuthInfo();



            this.StartCommand = new StartBotCommand(this, botRepository, authService, resolver);
            this.StopCommand = new StopBotCommand(this);
            this.RestartCommand = new RestartBotCommand(this);
        }
        #region Свойства авторизации
        private bool authenabled;

        public bool AuthEnabled
        {
            get { return botInfo.IsAuth; }
            set
            {
                botInfo.IsAuth = value;
                OnPropertyChanged();
            }
        }



        public AccountType AccType
        {
            get { return botInfo.AccType; }
            set
            {
                botInfo.AccType = value;
                OnPropertyChanged();
            }
        }



        public string Password
        {
            get { return botInfo.Password; }
            set
            {
                botInfo.Password = value;
                OnPropertyChanged();
            }
        }





        public string Nickname
        {
            get { return botInfo.Nickname; }
            set
            {
                botInfo.Nickname = value;
                OnPropertyChanged();
            }
        }
        #endregion



        public string Host
        {
            get { return botInfo.Host; }
            set
            {
                botInfo.Host = value;
                OnPropertyChanged();
            }
        }

        private State state;

        public State BotState
        {
            get { return state; }
            internal set
            {

                state = value;
                OnPropertyChanged();
            }
        }

        public Guid? UUID
        {
            get
            {
                return Client?.UUID;
            }

        }



        public Point3? Location
        {
            get
            {
                return Client?.Location;
            }
        }



        public Point3_Int? ChunkLocation
        {
            get
            {
                return this.Location?.ChunkPos;
            }

        }


        public Point3_Int? ChunkBlockLocation
        {
            get
            {
                return this.Location?.ChunkBlockPos;
            }
        }



        public Rotation? Rotation
        {
            get
            {
                return this.Client?.Rotation;
            }
        }


        private string _message;

        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                OnPropertyChanged();
            }
        }


        #region Errors        
        public CheckStatusVM AuthStatus { get; set; } = new();
        public CheckStatusVM ServerStatus { get; set; } = new();
        public CheckStatusVM ProxyStatus { get; set; } = new();
        public CheckStatusVM VersionStatus { get; set; } = new();
        #endregion

        #region Команды

        public ICommand StartCommand { get; private set; }

        public ICommand StopCommand { get; private set; }

        public ICommand RestartCommand { get; private set; }



        #endregion

        private ICommand clearchat;
        public ICommand ClearChatCommand
        {
            get => clearchat ??= new RelayCommand(() =>
            {
                Messages.Clear();
            });
        }
        private ICommand sendmessage;
        public ICommand SendMessageCommand
        {
            get => sendmessage ??= new RelayCommand(() =>
            {
                try
                {
                    Client?.SendChat(Message);
                    Message = "";
                }
                catch
                {

                }
            });
        }

        public ObservableCollection<ChatMessage> Messages { get; } = new ObservableCollection<ChatMessage>();
        public void ReturnToOrgignalStateStatuses()
        {
            BotState = State.None;

            AuthStatus.IsEnabled = false;
            ServerStatus.IsEnabled = false;
            ProxyStatus.IsEnabled = false;
            VersionStatus.IsEnabled = false;
        }

        public void RefreshPropertis()
        {
            this.OnPropertyChanged(string.Empty);
        }



        public override void Dispose()
        {
            //bot?.Dispose();
        }
    }
}
