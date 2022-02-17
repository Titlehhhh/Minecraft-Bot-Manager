using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;

namespace MinecraftBotManagerWPF.ViewModels
{
    public class BotViewModel : ObservableObject
    {
        private string nick;

        public string Username
        {
            get
            {
                return nick;
            }
            set
            {
                nick = value;
                OnPropertyChanged();
            }
        }

    }
}
