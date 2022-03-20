using Microsoft.Toolkit.Mvvm.Input;
using System;

namespace MinecraftBotManagerWPF
{
    public class BotViewModel : ViewModelBase, ICloneable
    {
        //public MainViewModel ParentVM => _parentVM;



        #region Сервисы





        #endregion

        public BotViewModel(object g)
        {









        }

        public string Nickname
        {
            get { return ""; }
            set
            {

                OnPropertyChanged();
            }
        }

        public string Host
        {
            get { return ""; }
            set
            {
                //bot.Host = value;
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

                //CheckServer();


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
