using Microsoft.Toolkit.Mvvm.Input;
using MinecraftLibrary.Geometry;
using MinecraftLibrary.PluginAPI;
using System;

namespace MinecraftBotManagerWPF
{
    public class BotViewModel : ViewModelBase
    {

        public BotInfo BotInfoModel => botInfo;

        private MinecraftBot bot;

        private readonly BotInfo botInfo;
        private readonly MinecraftBotFactory factory;

        public BotViewModel(BotInfo botInfo, MinecraftBotFactory factory)
        {
            if (botInfo is null)
                throw new ArgumentNullException(nameof(botInfo));
            this.botInfo = botInfo;
            this.factory = factory;
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
               ReturnToOrgignalStateStatuses();

               this.bot = factory.CreateBot(this.botInfo);

               bot.ProtocolClient.PropertyChanged += (s, e) =>
               {
                   this.OnPropertyChanged(e.PropertyName);
               };

               bot.StartBot();


           }, () => true);
        }


        private RelayCommand stop;

        public RelayCommand StopCommand
        {
            get => stop ??= new RelayCommand(() =>
            {

            }, () => false);
        }

        private RelayCommand restart;

        public RelayCommand RestartCommand
        {
            get => restart ??= new RelayCommand(() =>
            {

            }, () => false);
        }



        #endregion
        private void ReturnToOrgignalStateStatuses()
        {
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
