using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using MinecraftBotManagerWPF.Interfaces;
using MinecraftBotManagerWPF.Models;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Linq;
using MinecraftBotManagerWPF.Commands;
using System.Collections.Generic;

namespace MinecraftBotManagerWPF.ViewModels
{
    public interface IMainVM
    {
        BotViewModelsStorage Storage { get; }
        BotViewModel CurrentBot { set; }

        ICommand CreateNewBotCommand { get; }
        ICommand DeleteBotCommand { get; }
        ICommand CloseCommand { get; }
    }


    public class MainViewModel : ViewModelBase
    {
        

        public BotViewModel CurrentBot
        {
            get => BotVMStorage.CurrentBot;
            set
            {
                BotVMStorage.CurrentBot = value;
            }
        }
        public BotViewModelsStorage BotVMStorage { get; }

        public ObservableCollection<BotViewModel> BotsCollection => BotVMStorage.Bots;

        

        private readonly IDialogService dialogService;
        private readonly IDataService dataService;

        public MainViewModel(BotViewModelsStorage botStorage, IDialogService dialogService, IDataService dataService)
        {
            this.dialogService = dialogService;
            this.dataService = dataService;
            this.BotVMStorage = botStorage;


            CreateNewBotCommand = new AddBotCommand(botStorage, dataService.BotRepository);

            CurrentBot = BotsCollection.FirstOrDefault();
        }


        private void CreateBot()
        {

        }

        private void CloseWindow()
        {
            this.dataService.Save();
        }


        public ICommand CreateNewBotCommand { get; }

        public ICommand DeleteBotCommand { get; }



        private ICommand close;

        public ICommand CloseCommand
        {
            get => close ??= new RelayCommand(CloseWindow);
        }


    }

}
