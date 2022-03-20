using Microsoft.Toolkit.Mvvm.Input;
using MinecraftLibrary.PluginAPI;
using System;

namespace MinecraftBotManagerWPF
{
    public class BotViewModel : ViewModelBase
    {



        private readonly IMinecraftBot bot;

        public BotViewModel(IMinecraftBot bot)
        {
            this.bot = bot;
        }

        public string Nickname
        {
            get { return bot.Nickname; }
            set
            {
                bot.Nickname = value;
                OnPropertyChanged();
            }
        }

        public string Host
        {
            get { return bot.Host; }
            set
            {
                bot.Host = value;
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
            get => start ??= new RelayCommand(async () =>
            {
                ReturnToOrgignalStateStatuses();

               

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




        public object Clone()
        {
            return null;

        }

        public override void Dispose()
        {
            //Model.Dispose();
        }
    }
}
