﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using MinecraftBotManagerWPF.Enums;
using MinecraftLibrary.API.Types.Chat;

namespace MinecraftBotManagerWPF.ViewModels
{
    public class BotViewModel : ObservableObject, ICloneable
    {


        public BotViewModel()
        {
            chatqueue = new ObservableCollection<ChatMessage>();
            chatqueue_readonly = new ReadOnlyObservableCollection<ChatMessage>(chatqueue);


        }

        private bool isselected;

        public bool IsSelectedChat
        {
            get { return isselected; }
            set
            {
                isselected = value;
                CountUnReadMessages = 0;
                OnPropertyChanged();
            }
        }


        #region Чат


        private readonly ObservableCollection<ChatMessage> chatqueue;
        private readonly ReadOnlyObservableCollection<ChatMessage> chatqueue_readonly;
        public ReadOnlyObservableCollection<ChatMessage> ChatQueue => chatqueue_readonly;

        private int unreadmessages;

        public int CountUnReadMessages
        {
            get { return unreadmessages; }
            set
            {
                if (!(IsSelectedChat || value == unreadmessages))
                {
                    unreadmessages = value;
                    OnPropertyChanged();
                }
            }
        }
        private int unviewmessages;

        public int CountUnViewMessages
        {
            get { return unviewmessages; }
            set
            {
                unviewmessages = value;
                OnPropertyChanged();
            }
        }

        private string message;

        public string CurrentMessage
        {
            get { return message; }
            set
            {
                message = value;                
            }
        }

        private void ClearMessage()
        {
            CurrentMessage = "";
            OnPropertyChanged(nameof(CurrentMessage));
        }

        private RelayCommand send;

        public RelayCommand SendChatCommand
        {
            get => send ??= new RelayCommand(() =>
            {
                ClearMessage();
            });

        }



        #endregion

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
                AuthStatus.Status = StatusCheck.Ok;
                AuthStatus.Message = "Авторизация успешна";



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




        public object Clone()
        {

            return new BotViewModel();
        }
    }
}
