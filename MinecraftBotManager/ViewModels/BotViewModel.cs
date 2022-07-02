using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml.Media.Imaging;
using MinecraftBotManager.Api.Models;

namespace MinecraftBotManager.ViewModels
{
    [ObservableObject]
    public sealed partial class BotViewModel
    {
        #region Commands

        private RelayCommand startBotCommand;
        public RelayCommand StartBotCommand
        {
            get => startBotCommand ?? (startBotCommand = new RelayCommand(() =>
            {

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



        public string Host
        {
            set
            {

            }
            get
            {
                return "asd";
            }
        }



        #endregion

        public Bot bot;

        public BotViewModel(Bot bot)
        {
            this.bot = bot;
            bot.PropertyChanged += (s, e) =>
            {
                OnPropertyChanged(e.PropertyName);
            };
        }
    }
}
