using System.Collections.ObjectModel;

namespace MinecraftBotManagerWPF
{
    public class DesignMainVM : ViewModelBase
    {
        public ObservableCollection<BotViewModel> BotsCollection { get; } = new();
        public object SelectedBot { get; set; }
        public DesignMainVM()
        {
            var bot = new BotViewModel(new BotInfo());
            BotsCollection.Add(bot);
            SelectedBot = bot;
        }
    }

}
