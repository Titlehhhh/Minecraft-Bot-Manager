using CommunityToolkit.Mvvm.ComponentModel;

namespace MinecraftBotManager.ViewModels
{
    public partial class StatusVM : ObservableObject
    {
        private string text;

        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }

        private bool isEnabled;

        public bool IsEnabled
        {
            get => isEnabled;
            set => SetProperty(ref isEnabled, value);
        }

        private Status status;

        public Status Status
        {
            get => status;
            set => SetProperty(ref status, value);
        }
        public StatusVM()
        {
            Disabled();
        }

        public void Disabled()
        {
            IsEnabled = false;
        }

        public void Error(string text)
        {
            IsEnabled = true;
            Text = text;
            Status = Status.Error;
        }
        public void Ok(string text)
        {
            IsEnabled = true;
            Text = text;
            Status = Status.Ok;
        }
        public void Warn(string text)
        {
            IsEnabled = true;
            Text = text;
            Status = Status.Warning;
        }
        public void Load(string text)
        {
            IsEnabled = true;
            Text = text;
            Status = Status.Loading;
        }

        public void Load()
        {
            IsEnabled = true;
            Text = "";
            Status = Status.Loading;
        }

    }
    public enum Status
    {
        Ok,
        Error,
        Warning,
        Loading
    }
}
