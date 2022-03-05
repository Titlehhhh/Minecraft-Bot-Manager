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
            //BotsCollection.Add(new BotViewModel());
        }

        private RelayCommand? createCommand;

        public RelayCommand? CreateNewBotCommand
        {
            get => createCommand ??= new RelayCommand(async () =>
            {

                BotsCollection.Add(CreateBot());

            });
        }

        private RelayCommand<BotViewModel> delete;

        public RelayCommand<BotViewModel> DeleteBotCommand
        {
            get => delete ??= new RelayCommand<BotViewModel>((p) =>
            {

            });

        }



        private BotViewModel CreateBot()
        {
            BotViewModel botvm = new BotViewModel();


            return botvm;
        }
    }

}
