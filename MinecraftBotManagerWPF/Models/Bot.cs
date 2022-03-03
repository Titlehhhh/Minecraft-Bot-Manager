using System.ComponentModel;

namespace MinecraftBotManagerWPF.Models
{
    public sealed class Bot : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
