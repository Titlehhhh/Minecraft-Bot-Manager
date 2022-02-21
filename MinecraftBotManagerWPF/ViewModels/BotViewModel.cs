using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using MinecraftBotManagerWPF.Enums;

namespace MinecraftBotManagerWPF.ViewModels
{
    public class BotViewModel : ObservableObject, ICloneable
    {


        public BotViewModel()
        {

        }

        #region Свойства

        private string nick;

        public string Username
        {
            get
            {
                return nick;
            }
            set
            {
                nick = value;
                OnPropertyChanged();
            }
        }

        private string host;

        public string Host
        {
            get { return host; }
            set
            {
                host = value;
                OnPropertyChanged();
            }
        }
        private string port;

        public string Port
        {
            get { return port; }
            set
            {
                port = value;
                OnPropertyChanged();
            }
        }

        private State state;

        public State BotState
        {
            get { return state; }
            set
            {
                state = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Errors
        private string auth;

        public string AuthorizationError
        {
            get { return auth; }
            set
            {
                auth = value;
                OnPropertyChanged();
            }
        }

        private string iperror;

        public string IPAddresError
        {
            get { return iperror; }
            set
            {
                iperror = value;
                OnPropertyChanged();
            }
        }
        private string proxyerr;

        public string ProxyError
        {
            get { return proxyerr; }
            set
            {
                proxyerr = value;
                OnPropertyChanged();
            }
        }





        #endregion

        #region Команды

        private RelayCommand start;

        public RelayCommand StartCommand
        {
            get => start ??= new RelayCommand(() =>
            {

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

            }, () => BotState == State.Running);
        }

        private ICommand delete;

        public ICommand DeleteCommand
        {
            get { return delete ??= new RelayCommand(() => { }); }
            set { delete = value; }
        }

        private ICommand copy;

        public ICommand CopyCommand
        {
            get { return copy ??= new RelayCommand(() => { }); }
            set { copy = value; }
        }


        #endregion
        private void ClearErrorProperties()
        {
            AuthorizationError = "";
            IPAddresError = "";
            ProxyError = "";

            Step = StepCheck.None;
        }

        private StepCheck step;

        public StepCheck Step
        {
            get { return step; }
            private set
            {
                step = value;
                OnPropertyChanged();
            }
        }


        
        public object Clone()
        {
            return new BotViewModel();
        }
    }
    
}
