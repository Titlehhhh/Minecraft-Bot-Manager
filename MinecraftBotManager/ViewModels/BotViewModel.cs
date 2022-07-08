using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml.Media.Imaging;
using MinecraftBotManager.Api.Models;
using MinecraftBotManager.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace MinecraftBotManager.ViewModels
{
    [ObservableObject]
    public sealed partial class BotViewModel
    {
        #region Commands

        private RelayCommand startBotCommand;
        public RelayCommand StartBotCommand
        {
            get => startBotCommand ?? (startBotCommand = new RelayCommand(async () =>
            {
                ServerStatus.Disabled();
                ServerStatus.Load("Получение Srv...");
                await Task.Delay(3000);
                ServerStatus.Ok("Сервер tcp.Examle.com");
            }));
        }
        private RelayCommand stopBotCommand;
        public RelayCommand StopBotCommand
        {
            get => stopBotCommand ?? (stopBotCommand = new RelayCommand(() =>
            {

            }));
        }

        private RelayCommand deleteCommand;
        public RelayCommand DeleteCommand
        {
            get => deleteCommand ?? (deleteCommand = new RelayCommand(() =>
            {

            }));
        }

        #endregion

        #region Properties

        private BitmapImage icon;

        public BitmapImage Icon
        {
            get { return icon; }
            private set
            {
                icon = value;
                OnPropertyChanged();
            }
        }



        public string Username
        {
            get => bot.Username;
            set { bot.Username = value; }
        }

        private string host;

        public string Host
        {
            get => host;
            set
            {
                System.Console.WriteLine("sethst");
                host = value;
                SetProperty(ref host, value);
                

            }

        }

        public ObservableCollection<string> LocalIps { get; } = new();

        #endregion

        #region Errors
        public StatusVM ServerStatus { get; private set; } = new();
        #endregion

        private Bot bot;

        public BotViewModel(Bot bot)
        {
            LocalIps.Add("asdasd");
            this.bot = bot;
            bot.PropertyChanged += (s, e) =>
            {
                OnPropertyChanged(e.PropertyName);
            };
        }
    }
    
}
