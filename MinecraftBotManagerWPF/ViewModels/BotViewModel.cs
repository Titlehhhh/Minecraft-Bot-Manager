using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

                AuthStatus.IsEnabled = true;
                AuthStatus.Message = "Авторизация";
                AuthStatus.Status = StatusCheck.Init;
                await Auth();
                AuthStatus.Status = StatusCheck.Error;
                AuthStatus.Message = "Неверный логин или пароль";

                
                return;

                IPStatus.IsEnabled = true;

                IPStatus.Message = "Проверка ip адреса";
                IPStatus.Status = StatusCheck.Init;
                await Task.Delay(2000);
                IPStatus.Message = "IP адрес корректен";
                IPStatus.Status = StatusCheck.Ok;

                ProxyStatus.IsEnabled = true;
                ProxyStatus.Status = StatusCheck.Init;
                ProxyStatus.Message = "Ищем оптимальный сервер";
                await Task.Delay(2000);

                ProxyStatus.Status = StatusCheck.Ok;
                ProxyStatus.Message = "Оптимальный сервер найден!\n145.4.2.14:34565\nГонконг";

                VersionStatus.IsEnabled = true;
                VersionStatus.Status = StatusCheck.Ok;
                VersionStatus.Message = "Ок";

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

        private async Task Auth()
        {
            await Task.Delay(2000);
        }

        #endregion
        private void ReturnToOrgignalStateStatuses()
        {
            AuthStatus.IsEnabled = false;
            IPStatus.IsEnabled = false;
            ProxyStatus.IsEnabled = false;
            VersionStatus.IsEnabled = false;
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
    public class CheckStatus : INotifyPropertyChanged
    {
        private StatusCheck status;

        public StatusCheck Status
        {
            get { return status; }
            set
            {
                status = value;
                OnPropertyChanged();
            }
        }
        private string message;

        public string Message
        {
            get { return message; }
            set
            {
                message = value;
                OnPropertyChanged();
            }
        }

        private bool enabled;

        public bool IsEnabled
        {
            get { return enabled; }
            set
            {
                enabled = value;
                OnPropertyChanged();
            }
        }



        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
