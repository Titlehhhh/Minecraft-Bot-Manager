using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace MinecraftBotManagerWPF.ViewModels
{
    public class StartupVM : ObservableObject
    {
        private int progress;

        public int Progress
        {
            get { return progress; }
            set
            {
                progress = value;
                this.OnPropertyChanged();
            }
        }
        public Action LoadingSucces;

        public StartupVM(Action action)
        {
            LoadingSucces = action;
            Load();
        }
        private async void Load()
        {
            for(int i = 1; i <= 100; i++)
            {
                await Task.Delay(50);
                Progress = i;
            }
            
            LoadingSucces.Invoke();
        }
    }
}
