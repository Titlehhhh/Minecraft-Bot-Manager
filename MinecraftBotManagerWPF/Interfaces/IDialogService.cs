using MinecraftBotManagerWPF.ViewModels;
using System.Threading.Tasks;

namespace MinecraftBotManagerWPF.Interfaces
{
    public interface IDialogService
    {
        Task<bool?> ShowDialog(string quest);
        
    }
}
