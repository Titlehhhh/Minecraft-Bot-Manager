using Microsoft.Toolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace MinecraftBotManagerWPF.ViewModels
{
    public class DesignMainVM : ObservableObject
    {
        public ObservableCollection<BotViewModel> BotsCollection { get; } = new();
        public object SelectedBot { get; set; }
        public DesignMainVM()
        {
            var bot = new BotViewModel();
            BotsCollection.Add(bot);
            SelectedBot = bot;
        }
    }

}
