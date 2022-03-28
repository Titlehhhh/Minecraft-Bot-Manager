using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MinecraftBotManagerWPF
{
    public class ViewModelBase : INotifyPropertyChanged, IDisposable
    {
        public virtual void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public virtual void Dispose()
        {

        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }

}
