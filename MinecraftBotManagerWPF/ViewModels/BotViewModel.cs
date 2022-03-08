using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using MinecraftBotManagerWPF.Enums;
using MinecraftBotManagerWPF.Interfaces;
using MinecraftBotManagerWPF.Models;
using MinecraftLibrary.API.Types.Chat;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MinecraftBotManagerWPF.ViewModels
{
    public class BotViewModel : ObservableObject, ICloneable
    {

        public Bot MainBot { get; private set; }

        #region Сервисы
        
        #endregion

        public BotViewModel(Bot bot)
        {
            //this.dataService = dataService;

            MainBot = bot;
            bot.PropertyChanged += (s, e) =>
            {
                OnPropertyChanged(e.PropertyName);
            };

            chatqueue = new ObservableCollection<ChatMessage>();
            chatqueue_readonly = new ReadOnlyObservableCollection<ChatMessage>(chatqueue);


        }
        public BotViewModel()
        {
            MainBot = new Bot();
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



        public string Nickname
        {
            get { return MainBot.Nickname; }
            set
            {
                MainBot.Nickname = value;
                OnPropertyChanged();
            }
        }

        public string Host
        {
            get { return MainBot.Host; }
            set
            {
                MainBot.Host = value;
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

                CheckServer();


            }, () => MainBot.BotState == State.None);
        }

        private void CheckServer()
        {

        }

        private RelayCommand stop;

        public RelayCommand StopCommand
        {
            get => stop ??= new RelayCommand(() =>
            {

            }, () => MainBot.BotState != State.None);
        }

        private RelayCommand restart;

        public RelayCommand RestartCommand
        {
            get => restart ??= new RelayCommand(() =>
            {

            }, () => MainBot.BotState == State.Running);
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

            return new BotViewModel(new Bot());
        }
    }
}
