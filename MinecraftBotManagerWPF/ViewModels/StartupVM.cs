using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Threading.Tasks;

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
            for (int i = 1; i <= 100; i++)
            {
                await Task.Delay(1);
                Progress = i;
            }

            LoadingSucces.Invoke();
        }
    }
}
