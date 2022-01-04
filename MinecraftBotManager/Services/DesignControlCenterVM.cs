using GalaSoft.MvvmLight;
using MinecraftBotManager.ViewModel;
using MinecraftLibrary.MinecraftModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftBotManager.Services
{
    public class DesignControlCenterVM : ViewModelBase
    {
        public ObservableCollection<BotObjectVM> Bots { get; set; } = new ObservableCollection<BotObjectVM>
        {
            new BotObjectVM(new BotObject(){Nickname="asd"},null,null,null,null)
        };
        public List<MinecraftModule> Modules => new List<MinecraftModule>
        {
            new TestModule(null)
        };
        public DesignControlCenterVM()
        {

        }
    }
    public class TestModule : MinecraftModule
    {
        public int MyProperty { get; set; } = 45;
        public TestModule(BotObject mainBot) : base(mainBot,null)
        {
        }
    }

}
