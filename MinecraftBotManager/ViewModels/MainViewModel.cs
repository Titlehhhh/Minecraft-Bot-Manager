using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MinecraftBotManager.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MinecraftBotManager.ViewModels
{
    public sealed partial class MainViewModel : ObservableObject
    {
        public ICommand ClosedCommand { get; private set; }

        public MainViewModel(IBotRepository botRepository)
        {
            ClosedCommand = new RelayCommand(() => botRepository.Save().Wait());
        }
    }
}
