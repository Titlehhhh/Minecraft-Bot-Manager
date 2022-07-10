using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MinecraftBotManager.Contracts.Services;
using MinecraftBotManager.Data;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Windows.Storage;

namespace MinecraftBotManager.ViewModels
{

    public sealed partial class HomeViewModel : ObservableObject
    {
        private BotViewModel selectedBot;

        public BotViewModel SelectedBot
        {
            get { return selectedBot; }
            set
            {
                SetProperty(selectedBot, value,Call);
                Trace.WriteLine("setprop: " + value?.Username);
            }
        }

        private void Call(BotViewModel bot)
        {
            selectedBot = bot;
        }

        private int selectedindex;

        public int SelectedIndex
        {
            get => selectedindex;
            set => SetProperty(ref selectedindex, value);
        }

        [ICommand]
        public async Task Add()
        {

            var bot = new BotViewModel(new(), DeleteCommand);
            Bots.Add(bot);
            botRepository.Add(bot);
            await botRepository.Save();
            Trace.WriteLine("asd");
        }

        [ICommand]
        public async Task Delete(BotViewModel viewModel)
        {
            Bots.Remove(viewModel);
            botRepository.Remove(viewModel);

            await botRepository.Save();
            viewModel.Dispose();
        }
        private readonly IBotRepository botRepository;

        public HomeViewModel(IBotRepository botRepository)
        {


            this.botRepository = botRepository;

            foreach (var bot in botRepository.GetAllBots())
            {
                BotViewModel viewModel = new BotViewModel(bot, this.DeleteCommand);
                Bots.Add(viewModel);
            }


        }

        public ObservableCollection<BotViewModel> Bots { get; private set; } = new();


    }
}
