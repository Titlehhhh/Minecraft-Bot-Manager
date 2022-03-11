using MinecraftBotManagerWPF.Interfaces;
using MinecraftBotManagerWPF.Models;
using MinecraftBotManagerWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MinecraftBotManagerWPF.Commands
{
    public class AddBotCommand : ICommand
    {
        private readonly IBotRepository botRepository;
        private readonly MainViewModel mainViewModel;

        public AddBotCommand(IBotRepository botRepository, MainViewModel mainViewModel)
        {
            this.botRepository = botRepository;
            this.mainViewModel = mainViewModel;
        }

        public AddBotCommand()
        {

        }


        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            Bot bot = new Bot();
            BotViewModel botViewModel = new BotViewModel(bot);

            botRepository.AddBot(bot);

            mainViewModel.BotsCollection.Add(botViewModel);

            mainViewModel.CurrentBot = botViewModel;

        }
    }
}
