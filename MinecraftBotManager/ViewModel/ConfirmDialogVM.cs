using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftBotManager.ViewModel
{
    public class ConfirmDialogVM : ViewModelBase
    {
        private string title;

        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                RaisePropertyChanged();
            }
        }

        public ConfirmDialogVM()
        {
            Title = "Вы подвержаете действие?";
        }
        public ConfirmDialogVM(string title)
        {
            Title = title;
        }
    }
}
