using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using MinecraftBotManagerWPF.Interfaces;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

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

        public MainViewModel(IDialogService dialogService)
        {
            this.dialogService = dialogService;           
        }

        private ICommand? createCommand;

        public ICommand? CreateNewBotCommand
        {
            get => createCommand ??= new RelayCommand(() =>
            {
                BotsCollection.Add(CreateBot());
            });
        }

        private ICommand delete;

        public ICommand DeleteBotCommand
        {
            get => delete ??= new RelayCommand(async () =>
            {
                bool b = await dialogService.ShowConfirmDialog("Вы точно хотите удалить?");
                if (b)
                {
                    BotsCollection.Remove((BotViewModel)SelectedBot);
                }
            });

        }



        private BotViewModel CreateBot()
        {
            BotViewModel botvm = new BotViewModel();


            return botvm;
        }
    }

}
