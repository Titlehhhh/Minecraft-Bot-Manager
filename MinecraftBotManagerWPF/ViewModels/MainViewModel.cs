using Microsoft.Toolkit.Mvvm.Input;
using MinecraftLibrary.Services;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace MinecraftBotManagerWPF
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




        private readonly IDataService dataService;

        public MainViewModel(IDialogService dialogService, IDataService dataService, BotViewModelsStorage botViewModelsStorage, IServerResolver resolver, IAuthService authService)
        {
            this.dataService = dataService;


            this.BotVMStorage = botViewModelsStorage;

            this.BotVMStorage.StateChanged += () =>
            {
                OnPropertyChanged(nameof(CurrentBot));
            };

            CreateNewBotCommand = new AddBotCommand(this.BotVMStorage, dataService.BotRepository, authService, resolver);
            DeleteBotCommand = new RemoveBotCommand(this.BotVMStorage, dialogService, dataService.BotRepository);

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
