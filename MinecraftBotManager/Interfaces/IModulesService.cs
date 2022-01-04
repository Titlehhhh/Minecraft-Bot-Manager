using MinecraftBotManager.Models;
using MinecraftLibrary.MinecraftModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftBotManager.Interfaces
{
    public delegate void LoadModule(object sender, ReferencePath newItem);
    public delegate void UnLoadModule(object sender, ReferencePath oldItem);
    public interface IModulesService
    {
        ObservableCollection<ReferencePath> Dlls { get; }
        event LoadModule LoadModuleChanged;
        event UnLoadModule UnLoadModuleChanged;
        ObservableCollection<Type> AllModules { get; }
        ObservableCollection<ChatCommand> Commands { get; }
        

    }
}
