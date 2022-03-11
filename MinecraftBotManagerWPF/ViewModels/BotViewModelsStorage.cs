using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftBotManagerWPF.ViewModels
{
    public class BotViewModelsStorage
    {
        public ObservableCollection<BotViewModel> Bots { get; }

        private BotViewModel _currentbot;

        public BotViewModel CurrentBot
        {
            get => _currentbot;
            set
            {
                _currentbot = value;
                OnStateChanged();
            }
        }
        public event Action? StateChanged;
        private void OnStateChanged()
        {
            StateChanged?.Invoke();
        }
        public BotViewModelsStorage(IEnumerable<BotViewModel> bots)
        {
            Bots = new ObservableCollection<BotViewModel>(bots);
        }
    }
}
