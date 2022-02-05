using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using System.Xml.Linq;
using MinecraftBotManager.Models;
using MinecraftBotManager.Interfaces;
using System.ComponentModel;
using Microsoft.Win32;
using MaterialDesignThemes.Wpf;

namespace MinecraftBotManager.ViewModel
{
    public class SettingsVM : ViewModelBase
    {
        public static readonly string SettingsFile = Path.Combine(Directory.GetCurrentDirectory(), "Data", "Settings.xml");

        private ReferencePath select;

        public ReferencePath SelectedItem
        {
            get { return select; }
            set
            {
                select = value;
                RaisePropertyChanged();
            }
        }
        public SettingsVM()
        {

        }

        public ObservableCollection<ReferencePath> Dlls { get; private set; } = new ObservableCollection<ReferencePath>();

        public ConfigModel Model { get; private set; }
        private readonly IDataService _dataservice;
        public SettingsVM(IDataService service, IModulesService modulesService)
        {
            
            Model = service.Config;
            _dataservice = service;

            Dlls = modulesService.Dlls;
        }



        private RelayCommand<object> del;

        public RelayCommand<object> DeleteElemnet
        {
            get => del ?? (del = new RelayCommand<object>(async p =>
            {
                if (SelectedItem != null)
                {
                    bool result = (bool)await DialogHost.Show(new ConfirmDialogVM(), "RootDialog");
                    if (result)
                    {

                    }
                }
            }));
        }



        private void Dlls_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {

        }

        public override void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.RaisePropertyChanged(propertyName);
        }

    }

}
