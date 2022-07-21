using Microsoft.UI.Xaml.Media.Imaging;
using System.Threading.Tasks;

namespace MinecraftBotManager.Contracts.Services
{
    public interface IIconService
    {
        Task<BitmapImage> GetIconFromNick(string nick);
    }
}
