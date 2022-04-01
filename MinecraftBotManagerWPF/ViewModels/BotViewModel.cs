using Microsoft.Toolkit.Mvvm.Input;
using MinecraftLibrary.API.Types.Chat;
using MinecraftLibrary.Geometry;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using MinecraftLibrary;

namespace MinecraftBotManagerWPF
{
    public class BotViewModel : ViewModelBase
    {
        internal MinecraftClient Client { get; set; }

        public BotInfo BotInfoModel => botInfo;



        private readonly BotInfo botInfo;
        private readonly IBotRepository _botRepository;

        public BotViewModel(BotInfo botInfo, IBotRepository botRepository)
        {
            if (botInfo is null)
                throw new ArgumentNullException(nameof(botInfo));
            this.botInfo = botInfo;
            this._botRepository = botRepository;
            //botInfo.Proxy = new MinecraftLibrary.API.Networking.Proxy.ProxyInfo();
            //  botInfo.Auth = new AuthInfo();

            BotVMHelper inizializer = new BotVMHelper(this);

            this.StartCommand = new StartBotCommand(this, botRepository);
            this.StopCommand = new StopBotCommand(inizializer);
            this.RestartCommand = new RestartBotCommand(inizializer);
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




        #region Errors        
        public CheckStatusVM AuthStatus { get; set; } = new();
        public CheckStatusVM IPStatus { get; set; } = new();
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

        public ObservableCollection<ChatMessage> Messages { get; } = new ObservableCollection<ChatMessage>();
        public void ReturnToOrgignalStateStatuses()
        {
            BotState = State.None;

            AuthStatus.IsEnabled = false;
            IPStatus.IsEnabled = false;
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
