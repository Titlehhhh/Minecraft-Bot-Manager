using MinecraftBotManagerWPF.Enums;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MinecraftBotManagerWPF.ViewModels
{
    public class CheckStatus : INotifyPropertyChanged
    {
        private StatusCheck status;

        public StatusCheck Status
        {
            get { return status; }
            set
            {
                status = value;
                OnPropertyChanged();
            }
        }
        private string message;

        public string Message
        {
            get { return message; }
            set
            {
                message = value;
                OnPropertyChanged();
            }
        }

        private bool enabled;

        public bool IsEnabled
        {
            get { return enabled; }
            set
            {
                enabled = value;
                OnPropertyChanged();
            }
        }



        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
