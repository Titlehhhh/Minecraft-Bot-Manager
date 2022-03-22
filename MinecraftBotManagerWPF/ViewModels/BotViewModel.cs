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

        private RelayCommand start;

        public RelayCommand StartCommand
        {
            get => start ??= new RelayCommand(() =>
           {
               try
               {
                   ReturnToOrgignalStateStatuses();
                   BotState = State.Initialized;
                   Client.Nickname = botInfo.Nickname;
                   

               }
               catch (Exception e)
               {
                   BotState = State.None;
                   Console.WriteLine(e);
               }


           }, () => BotState == State.None);
        }


        private RelayCommand stop;

        public RelayCommand StopCommand
        {
            get => stop ??= new RelayCommand(() =>
            {

            }, () => BotState != State.None);
        }

        private RelayCommand restart;

        public RelayCommand RestartCommand
        {
            get => restart ??= new RelayCommand(() =>
            {

            }, () => BotState != State.None);
        }



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
        private void ReturnToOrgignalStateStatuses()
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
