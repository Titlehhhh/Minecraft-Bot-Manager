using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using MinecraftBotManager.Models;
using GalaSoft.MvvmLight.Messaging;

using MinecraftLibrary.Data;
using MinecraftLibrary.MinecraftModels;
using Starksoft.Net.Proxy;
using System.Runtime.CompilerServices;
using MinecraftBotManager.Services;
using MinecraftBotManager.Messages;
using MinecraftBotManager.Interfaces;
using MaterialDesignThemes.Wpf;
using MinecraftLibrary.Interfaces;

namespace MinecraftBotManager.ViewModel
{
    public class BotObjectVM : INotifyPropertyChanged
    {
        public ProxyType[] ProxyTypes { get; private set; } = Enum.GetValues(typeof(ProxyType)).Cast<ProxyType>().ToArray();
        public string[] SupportedVersions { get; private set; } = {"1.12.2","1.16.5" };

        private BotObject Main;
        public BotObject MainModel => Main;
        public string Nickname
        {
            get => Main.Nickname;
            set
            {
                Main.Nickname = value;
                RaisePropertyChanged();

            }
        }

        public string Version
        {
            get => Main.Version;
            set
            {
                Main.Version = value;
                
                RaisePropertyChanged();
            }
        }
        public string Host
        {
            get => Main.Host;
            set
            {
                Main.Host = value;
                RaisePropertyChanged();
            }
        }
        public ushort Port
        {
            get => Main.Port;
            set
            {
                Main.Port = value;
                RaisePropertyChanged();
            }
        }
        public string ProxyHost
        {
            get => Main.ProxyHost;
            set
            {
                Main.ProxyHost = value;
                RaisePropertyChanged();
            }
        }
        public int ProxyPort
        {
            get => Main.ProxyPort;
            set
            {
                Main.ProxyPort = value;
                RaisePropertyChanged();
            }
        }



        public ObservableCollection<MinecraftModule> Modules
        {
            get { return MainModel.Modules; }
            set
            {
                MainModel.Modules = value;
                RaisePropertyChanged();
            }
        }


        private void RaisePropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public ProxyType PrxType
        {
            get => MainModel.PrxType;
            set
            {
                MainModel.PrxType = value;
                System.Diagnostics.Debug.WriteLine(value);
                RaisePropertyChanged();
            }
        }
        public string Gamemode { get => Main.Gamemode; }
        public string UUID { get => Main.UUID; }
        public string Health { get => Main.Health; }
        public string Current_Slot { get => Main.Current_Slot; }
        public string Position => $"X: {Main.Position.X} Y:{Main.Position.Y} Z:{Main.Position.Z}";
        private ObservableCollection<ChatMessage> chat;
        public ObservableCollection<ChatMessage> ChatQueue => chat ?? (chat = new ObservableCollection<ChatMessage>());
        public float Yaw => Main.Yaw;
        public float Pitch => Main.Pitch;
        
        public RunningStatus StatusLaunched { get => Main.StatusLaunched; }

        private readonly IDataService data;
        private readonly IDialogService dialogService;
        private readonly IMainViewModelController controller;
        private readonly IModulesService modules;
        public BotObjectVM(BotObject mainModel, IDataService dataService, IDialogService dialogService, IMainViewModelController controller, IModulesService modules)
        {
            this.controller = controller;
            this.dialogService = dialogService;
            this.modules = modules;

            
            data = dataService;
            Main = mainModel;
            Main.MainViewModelController = controller;
            Main.ChatQueue.CollectionChanged += (s, e) =>
            {
                try
                {
                    if (e.NewItems != null)
                        foreach (ChatMessage item in e.NewItems)
                            App.Current?.Dispatcher.Invoke(() => ChatQueue?.Add(item));
                    if (e.OldItems != null)
                        foreach (ChatMessage item in e.OldItems)
                            App.Current?.Dispatcher.Invoke(() => ChatQueue?.Remove(item));
                }
                catch
                {

                }
            };

            modules.UnLoadModuleChanged += (s,p) =>
            {
                foreach(Type t in p.Modules)
                {
                    Main.RemoveType(t);
                }
            };

            Main.PropertyChanged += (s, p) => { RaisePropertyChanged(p.PropertyName); };
        }
        private RelayCommand<object> startcommand;

        public RelayCommand<object> StartCommand
        {
            get => startcommand ?? (startcommand = new RelayCommand<object>(p =>
            {
                if (StatusLaunched == RunningStatus.None)
                    MainModel.StartClient();
                else
                    MainModel.Disconnect();
            }));
        }
        private RelayCommand<object> sendcommand;

        public RelayCommand<object> SendCommand
        {
            get => sendcommand ?? (sendcommand = new RelayCommand<object>(p =>
            {
                if (StatusLaunched != RunningStatus.None)
                {
                    Main.SendText(Message);
                    Message = "";
                }
            }));
        }
        private RelayCommand<object> restartcommand;

        public RelayCommand<object> RestartCommand
        {
            get => restartcommand ?? (restartcommand = new RelayCommand<object>((p) =>
            {
                MainModel.RestartClient();
            }));

        }

        public MinecraftModule SelectedModule { get; set; }

        private RelayCommand<object> addmodule;

        public RelayCommand<object> AddModuleCommand
        {
            get => addmodule ?? (addmodule = new RelayCommand<object>(p =>
            {
                Messenger.Default.Send<ShowAddElementMessage>(new ShowAddElementMessage());
                Messenger.Default.Register<CloseAddModuleMessage>(this, r =>
                {
                    Messenger.Default.Unregister<CloseAddModuleMessage>(this);
                    if (r.Result != null)
                    {
                        if (!MainModel.Modules.Select(x => x.GetType()).Contains(r.Result.GetType()))
                        {

                            if (r.Result != null)
                            {
                                try
                                {
                                    MainModel.AddModule(r.Result);
                                    data.Save();
                                }
                                catch (Exception e)
                                {
                                    dialogService.ShowMessageBox("Ошибка при добавлении модуля: " + "\n" + e.ToString());
                                }
                            }
                        }
                        else
                        {
                            dialogService.ShowMessageBox("Такой модуль уже есть!");
                        }
                    }
                });
            }));
        }
        private RelayCommand<object> deletemodule;

        public RelayCommand<object> DeleteModuleCommand
        {
            get => deletemodule ?? (deletemodule = new RelayCommand<object>(async p =>
           {
               MinecraftModule old = p as MinecraftModule;
               if (old != null)
               {
                   bool result = (bool)await DialogHost.Show(new ConfirmDialogVM("Вы точно хотите удалить?"), "RootDialog");
                   if (result)
                   {
                       MainModel.RemoveType(old.GetType());
                   }
               }
           }));
        }



        private string message;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Message
        {
            get { return message; }
            set
            {
                message = value;
                RaisePropertyChanged();
            }
        }
        
    }
    
}
