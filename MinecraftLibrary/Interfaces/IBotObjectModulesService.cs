using MinecraftLibrary.MinecraftModels;
using System.Collections.ObjectModel;

namespace MinecraftLibrary.Interfaces
{
    public interface IBotObjectModulesService
    {
        ObservableCollection<MinecraftModule> Modules { get; }
        void Register(MinecraftModule module);
        void UnRegister(MinecraftModule module);
    }
    
}
