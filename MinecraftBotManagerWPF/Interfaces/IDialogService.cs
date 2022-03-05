using System.Threading.Tasks;

namespace MinecraftBotManagerWPF.Interfaces
{
    public interface IDialogService
    {
        Task<bool> ShowConfirmDialog(string quest);

        object ShowDialog();
    }
}
