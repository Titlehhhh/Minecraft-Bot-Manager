using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MinecraftBotManager.Contracts.Services;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MinecraftBotManager.ViewModels
{
    public sealed partial class MainViewModel : ObservableObject
    {
        private readonly IBotRepository botRepository;

        [ICommand]
        private async Task Closed()
        {
            await botRepository.Save();
        }

        public MainViewModel(IBotRepository botRepository)
        {
            this.botRepository = botRepository;
        }
    }
}
