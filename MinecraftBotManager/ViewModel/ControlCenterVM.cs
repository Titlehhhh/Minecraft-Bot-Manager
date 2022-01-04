using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using MinecraftBotManager.Models;
using MaterialDesignThemes.Wpf;
using MinecraftBotManager.Views.UserControls;
using System.ComponentModel;
using MinecraftBotManager.Interfaces;
using MinecraftLibrary.MinecraftModels;
using MinecraftBotManager.Services;


namespace MinecraftBotManager.ViewModel
{
    public class ControlCenterVM : ViewModelBase
    {
        private readonly IDataService dataService;
        private readonly IDialogService dialogService;
        private readonly IModulesService modules;
        public  MainViewModel Parent { get; private set; }
        public ControlCenterVM(IDataService dataService,IModulesService modules,IDialogService dialogService, MainViewModel mainView)
        {
            this.Parent = mainView;
            this.modules = modules;
            this.dialogService = dialogService;
            this.dataService = dataService;
            dataService.BotsCollectionChanged += DataService_CollectionChanged;
            if (ViewModelBase.IsInDesignModeStatic)
            {
                Bots = new ObservableCollection<BotObjectVM>
                {
                    new BotObjectVM(new BotObject(){Nickname="asd" },dataService,dialogService,Parent,modules)
                };
            }
            Bots = new ObservableCollection<BotObjectVM>();
            foreach (var bot in dataService.GetAllBots())
            {
                BotObjectVM newElement = new BotObjectVM(bot,dataService,dialogService,Parent,modules);
                newElement.PropertyChanged += NewElement_PropertyChanged;
                Bots.Add(newElement);
            }
        }        

        private void DataService_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {

            if (e.NewItems != null)
                foreach (BotObject newItem in e.NewItems)
                {
                    BotObjectVM newElement = new BotObjectVM(newItem,dataService,dialogService, Parent,modules);
                    newElement.PropertyChanged += NewElement_PropertyChanged;
                    Bots.Add(newElement);
                }
            if (e.OldItems != null)
                foreach (BotObject old in e.OldItems)
                {
                    BotObjectVM bovm = Bots.FirstOrDefault(x => x.MainModel == old);
                    if (bovm != null)
                    {
                        Bots.Remove(bovm);
                        bovm.PropertyChanged -= NewElement_PropertyChanged;
                    }
                }

            dataService.Save();
        }

        private void NewElement_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            dataService.Save();
        }

        private ObservableCollection<BotObjectVM> _bots;

        public ObservableCollection<BotObjectVM> Bots
        {
            get { return _bots; }
            set
            {
                _bots = value;
                RaisePropertyChanged();
            }
        }



        #region Команды
        private RelayCommand<BotObject> deletecommand;

        public RelayCommand<BotObject> DeleteCommand
        {
            get => deletecommand ?? (deletecommand = new RelayCommand<BotObject>(async p =>
            {
                bool result = (bool)await DialogHost.Show(new ConfirmDialogVM("Вы точно хотите удалить?"));
                if (result && p != null)
                {
                    dataService.RemoveBot(p);
                    p.Disconnect();
                }
            }));
        }
        private RelayCommand<object> addbotcommand;

        public RelayCommand<object> AddNewBotCommand
        {
            get => addbotcommand ?? (addbotcommand = new RelayCommand<object>(p =>
            {
                BotObject newBot = new BotObject();
                dataService.AddBot(newBot);

            }));
        }


        private RelayCommand<object> restartallbot;

        public RelayCommand<object> RestartAllBotCommand => restartallbot ?? (restartallbot = new RelayCommand<object>(async p =>
        {
            bool result = (bool)await DialogHost.Show(new ConfirmDialogVM("Вы подтверждаете действие?"));
            if (result)
            {
                await Task.Run(() =>
                {
                    dataService.GetAllBots().ToList().ForEach(b => b.RestartClient());
                });
            }
        }));

        private RelayCommand<object> disconnectallbotcommand;

        public RelayCommand<object> DisconnectAllBotCommand => disconnectallbotcommand ?? (disconnectallbotcommand = new RelayCommand<object>(async p =>
        {
            bool result = (bool)await DialogHost.Show(new ConfirmDialogVM("Вы подтверждаете действие?"),"RootDialog");
            if (result)
            {
                await Task.Run(() =>
                {
                    dataService.GetAllBots().ToList().ForEach(b => b.Disconnect());
                });
            }
        }));
        private RelayCommand<object> startallbotcommand;

        public RelayCommand<object> StartAllBotCommand => startallbotcommand ?? (startallbotcommand = new RelayCommand<object>(async p =>
        {
            await Task.Run(() =>
            {
                dataService.GetAllBots().ToList().ForEach(b =>
                {
                    b.StartClient();
                });
            });
        }));




        #endregion
    }
    

}
