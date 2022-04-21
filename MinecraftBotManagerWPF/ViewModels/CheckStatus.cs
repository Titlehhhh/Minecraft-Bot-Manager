using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MinecraftBotManagerWPF
{
    public class CheckStatusVM : INotifyPropertyChanged
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

        public void Error(string message)
        {
            IsEnabled = true;
            Message = message;
            Status = StatusCheck.Error;
        }
        public void Succes(string message)
        {
            IsEnabled = true;
            Message = message;
            Status = StatusCheck.Ok;
        }
        public void Load(string message)
        {
            IsEnabled = true;
            Message = message;
            Status = StatusCheck.Init;
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
