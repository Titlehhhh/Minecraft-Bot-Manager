using Microsoft.Extensions.DependencyInjection;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MinecraftBotManagerWPF.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged, IDisposable
    {
        protected virtual void OnPropertyChanged([CallerMemberName]string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public virtual void Dispose()
        {
           
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }

}
