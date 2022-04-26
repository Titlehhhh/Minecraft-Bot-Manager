using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace MinecraftBotManagerWPF
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
        public BotViewModelsStorage(IBotRepository botRepository, IBotVMFactory factory)
        {
            var bots = botRepository.GetAllBots().Select(factory.Create);
            Bots = new ObservableCollection<BotViewModel>(bots);
        }
    }
}
