using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MinecraftBotManager.ViewModels
{

    public sealed class MainViewModel : ObservableObject
    {
        private BotViewModel selectedBot;

        public BotViewModel SelectedBot
        {
            get { return selectedBot; }
            set
            {
                SetProperty(ref selectedBot, value);
            }
        }

        private int selectedindex;

        public int SelectedIndex
        {
            get => selectedindex;
            set => SetProperty(ref selectedindex, value);
        }


        private AsyncRelayCommand addBotCommand;

        public AsyncRelayCommand AddBotCommand
        {
            get => addBotCommand ?? (addBotCommand = new AsyncRelayCommand(async () =>
            {
                Bots.Add(new BotViewModel(new Api.Models.Bot() { Username = "Bot"}));
            }));

        }





        public ObservableCollection<BotViewModel> Bots { get; private set; } = new();



        public MainViewModel()
        {
            Bots.Add(new BotViewModel(new()));
            SelectedBot = Bots.FirstOrDefault();
        }
    }
}
