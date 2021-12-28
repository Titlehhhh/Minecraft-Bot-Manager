using MinecraftBotManager.CustomControls.FileProvider;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace MinecraftBotManager.Interfaces
{
    public interface IStorageService
    {
        Task SaveObjectAsync(object data, string filename);
        Task<object> LoadObjectAsync(string filename);        
    }
}
