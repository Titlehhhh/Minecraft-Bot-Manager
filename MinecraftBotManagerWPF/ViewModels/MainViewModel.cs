using Microsoft.Toolkit.Mvvm.Input;
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



        private readonly IDialogService dialogService;
        private readonly IDataService dataService;

        public MainViewModel(IDialogService dialogService, IDataService dataService)
        {
            this.dialogService = dialogService;
            this.dataService = dataService;

            var bots = dataService.BotRepository
                .GetAllBots()
                .Select(bot => new BotViewModel(bot));
            this.BotVMStorage = new BotViewModelsStorage(bots);


            CreateNewBotCommand = new AddBotCommand(this.BotVMStorage, dataService.BotRepository);

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
