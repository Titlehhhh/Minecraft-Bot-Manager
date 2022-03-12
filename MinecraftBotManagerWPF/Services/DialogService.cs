using System.Threading.Tasks;
using System.Windows;

namespace MinecraftBotManagerWPF
{
    public class DialogService : IDialogService
    {
        private readonly Window owner;

        public DialogService(Window owner)
        {
            this.owner = owner;
        }

        public async Task<bool?> ShowDialog(string quest)
        {
            if (string.IsNullOrEmpty(quest))
            {
                quest = "Вы точно хотите удалить?";
            }
            ConfirmDialogWindow container = new ConfirmDialogWindow();
            container.QuestText.Text = quest;
            container.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            container.Owner = owner;
            return container.ShowDialog();
        }

        public object ShowDialog()
        {
            return null;
        }
    }
}
