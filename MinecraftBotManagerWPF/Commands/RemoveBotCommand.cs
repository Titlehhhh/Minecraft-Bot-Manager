﻿using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MinecraftBotManagerWPF
{
    public class RemoveBotCommand : AsyncCommandBase
    {
        private readonly IBotRepository botRepository;
        private readonly BotViewModelsStorage vmstorage;
        private readonly IDialogService dialogService;

        public RemoveBotCommand(BotViewModelsStorage vmstorage, IDialogService dialogService, IBotRepository botRepository)
        {
            this.botRepository = botRepository;
            this.vmstorage = vmstorage;
            this.dialogService = dialogService;
        }
        public override async Task ExecuteAsync(object parameter)
        {
            bool? b = await dialogService.ShowDialog("Вы точно хотите удалить?");
            if (b.Value)
            {
                BotViewModel currentBot = (BotViewModel)parameter;

                Bot bot = currentBot.Model;

                vmstorage.Bots.Remove(currentBot);                
                vmstorage.CurrentBot = vmstorage.Bots.FirstOrDefault();

                await botRepository.RemoveBot(bot);
            }
        }
    }
}
