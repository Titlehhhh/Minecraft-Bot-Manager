using MinecraftBotManagerWPF.Interfaces;
using MinecraftBotManagerWPF.Views.UserControls;
using MinecraftBotManagerWPF.Views.Windows;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace MinecraftBotManagerWPF.Services
{
    public class DialogService : IDialogService
    {
        private readonly Window mainWin;

        public DialogService(Window mainWin)
        {
            this.mainWin = mainWin ?? throw new ArgumentNullException(nameof(mainWin));
        }

        public async Task<bool> ShowConfirmDialog(string quest)
        {
            if (string.IsNullOrEmpty(quest))
            {
                quest = "Вы точно хотите удалить?";
            }
            ConfirmDialogWindow container = new ConfirmDialogWindow();
            container.QuestText.Text = quest;
            container.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            container.Owner = mainWin;            
            return container.ShowDialog().Value;
        }

        public object ShowDialog()
        {
            return null;
        }
    }
}
