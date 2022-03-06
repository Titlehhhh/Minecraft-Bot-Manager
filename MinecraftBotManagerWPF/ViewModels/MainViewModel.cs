using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using MinecraftBotManagerWPF.Interfaces;
using MinecraftBotManagerWPF.Models;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Linq;

namespace MinecraftBotManagerWPF.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        private object selectedbot;

        public object SelectedBot
        {
            get { return selectedbot; }
            set
            {
                selectedbot = value;
                OnPropertyChanged();
            }
        }


        public ObservableCollection<BotViewModel> BotsCollection { get; set; } = new();

        private readonly IDialogService dialogService;
        private readonly IDataService dataService;

        public MainViewModel(IDialogService dialogService, IDataService dataService)
        {
            this.dialogService = dialogService;
            this.dataService = dataService;

            LoadBots();
        }
        private void LoadBots()
        {
            foreach(Bot bot in dataService.BotRepository.GetAllBots())
            {
                BotsCollection.Add(new BotViewModel(bot));                
            }
            SelectedBot = BotsCollection.FirstOrDefault();
        }

        private void CreateBot()
        {
            Bot bot = new Bot();
            BotViewModel botViewModel = new BotViewModel(bot);
            dataService.BotRepository.AddBot(bot);
            BotsCollection.Add(botViewModel);
            SelectedBot = botViewModel;
        }

        private async void DeleteBotAsync()
        {
            bool b = await dialogService.ShowConfirmDialog("Вы точно хотите удалить?");
            if (b)
            {
                BotViewModel currentbot = (BotViewModel)SelectedBot;
                Bot bot = currentbot.MainBot;
                this.dataService.BotRepository.RemoveBot(bot);
                BotsCollection.Remove(currentbot);
                SelectedBot = BotsCollection.FirstOrDefault();
            }
        }

        private void CloseWindow()
        {
            this.dataService.BotRepository.Save();
        }

        private ICommand? createCommand;

        public ICommand? CreateNewBotCommand
        {
            get => createCommand ??= new RelayCommand(CreateBot);
        }

        private ICommand delete;

        public ICommand DeleteBotCommand
        {
            get => delete ??= new RelayCommand(DeleteBotAsync);
        }

        private ICommand close;

        public ICommand CloseCommand
        {
            get => close ??= new RelayCommand(CloseWindow);
        }


    }

}
