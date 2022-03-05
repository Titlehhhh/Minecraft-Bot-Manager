using MinecraftLibrary.Client;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MinecraftBotManagerWPF.Models
{
    public sealed class Bot : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private string nick;

        public string Nickname
        {
            get { return nick; }
            set
            {
                nick = value;
                OnPropertyChanged();
            }
        }


        public void StartClient()
        {
            MinecraftClient client = new MinecraftClient();
        }
        public void Stop()
        {

        }

        private void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
