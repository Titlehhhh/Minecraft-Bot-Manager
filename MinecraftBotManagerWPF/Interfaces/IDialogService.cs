using System.Threading.Tasks;

namespace MinecraftBotManagerWPF
{
    public interface IDialogService
    {
        Task<bool?> ShowDialog(string quest);

    }
}
