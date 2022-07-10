using Microsoft.UI.Xaml.Media.Imaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftBotManager.Contracts.Services
{
    public interface IIconService
    {
        Task<BitmapImage> GetIconFromNick(string nick);
    }
}
