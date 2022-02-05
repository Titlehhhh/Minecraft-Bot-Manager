using GalaSoft.MvvmLight;
using MinecraftBotManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace MinecraftBotManager.ViewModel
{
    public class AddModuleVM : ViewModelBase
    {        
        public ObservableCollection<Type> Modules { get;private set; }
        private readonly IModulesService modulesService;
        public AddModuleVM(IModulesService model)
        {
            modulesService = model;
            Modules = model.AllModules;
        }
    }
}
