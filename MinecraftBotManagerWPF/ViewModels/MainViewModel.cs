using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;

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
                BotsCollection.Add(new BotViewModel());
            });
        }


    }
}
