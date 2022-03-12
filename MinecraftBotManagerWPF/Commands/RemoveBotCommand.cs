using System;
using System.Windows.Input;

namespace MinecraftBotManagerWPF
{
    public class RemoveBotCommand : ICommand
    {
        private readonly IBotRepository botRepository;
        private readonly MainViewModel mainViewModel;

        public RemoveBotCommand(IBotRepository botRepository, MainViewModel mainViewModel)
        {
            this.botRepository = botRepository;
            this.mainViewModel = mainViewModel;
        }

        public RemoveBotCommand()
        {

        }


        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            BotViewModel currentBot = (BotViewModel)parameter;
            //TODO Сделать удаление
        }
    }
}
