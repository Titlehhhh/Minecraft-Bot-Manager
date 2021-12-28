using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MinecraftBotManager.Interfaces;
using System.Windows;

namespace MinecraftBotManager.Services
{
    public class DialogService : IDialogService
    {
        private Window owner;
        public DialogService(Window owner)
        {
            this.owner = owner;
        }
        public void ShowMessageBox(string content)
        {
            Task.Run(() => owner.Dispatcher.Invoke(() => MessageBox.Show(owner, content)));
        }
    }
}
