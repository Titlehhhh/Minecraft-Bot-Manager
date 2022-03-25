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

        public BotInfo BotInfoModel => botInfo;



        private readonly BotInfo botInfo;

        public BotViewModel(BotInfo botInfo)
        {
            if (botInfo is null)
                throw new ArgumentNullException(nameof(botInfo));
            this.botInfo = botInfo;
            botInfo.Proxy = new MinecraftLibrary.API.Networking.Proxy.ProxyInfo();
            botInfo.Auth = new AuthInfo();

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

        private AuthInfo pass;

        public AuthInfo Password
        {
            get { return botInfo.Auth.Password; }
            set
            {
                
                OnPropertyChanged();
            }
        }




        public string Nickname
        {
            get { return botInfo.Nickname; }
            set
            {
                botInfo.Auth.Login = value;
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
            private set
            {

                state = value;
                OnPropertyChanged();
            }
        }

        private Guid uuid;

        public Guid UUID
        {
            get { return uuid; }
            private set
            {
                uuid = value;
                OnPropertyChanged();
            }
        }
        private Point3 location;

        public Point3 Location
        {
            get { return location; }
            private set
            {
                location = value;
                OnPropertyChanged();
            }
        }

        private Point3_Int chunkloc;

        public Point3_Int ChunkLocation
        {
            get { return chunkloc; }
            private set
            {
                chunkloc = value;
                OnPropertyChanged();
            }
        }
        private Point3_Int chblockloc;

        public Point3_Int ChunkBlockLOcation
        {
            get { return chblockloc; }
            private set
            {
                chblockloc = value;
                OnPropertyChanged();
            }
        }

        private Rotation rotation;

        public Rotation Rotation
        {
            get { return rotation; }
            private set
            {
                rotation = value;
                OnPropertyChanged();
            }
        }




        #region Errors        
        public CheckStatus AuthStatus { get; set; } = new();
        public CheckStatus IPStatus { get; set; } = new();
        public CheckStatus ProxyStatus { get; set; } = new();
        public CheckStatus VersionStatus { get; set; } = new();
        #endregion

        #region Команды

        public ICommand StartBotCommand { get; private set; }

        public ICommand StopBotCommand { get; private set; }

        public ICommand RestartBotCommand { get; private set; }



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



        public override void Dispose()
        {
            bot?.Dispose();
        }
    }
}
