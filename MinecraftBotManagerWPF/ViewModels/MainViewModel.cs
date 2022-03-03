using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MinecraftBotManagerWPF.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        public ObservableCollection<BotViewModel> BotsCollection { get; set; } = new();


        public MainViewModel()
        {
            BotsCollection.Add(new BotViewModel());
        }

        private RelayCommand? createCommand;

        public RelayCommand? CreateNewBotCommand
        {
            get => createCommand ??= new RelayCommand(() =>
            {
                BotsCollection.Add(CreateBot());
            });
        }




        private BotViewModel CreateBot()
        {
            BotViewModel botvm = new BotViewModel();




            return botvm;
        }
    }
    internal class CloneBotCommand : ICommand
    {



        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {

        }
    }
}
