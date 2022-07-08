using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MinecraftBotManager.Api.Models
{
    public sealed class Bot : INotifyPropertyChanged
    {
        private string username;

        public string Username
        {
            get { return username; }
            set
            {
                username = value;
                OnPropertyChaned();
            }
        }




        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChaned([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
