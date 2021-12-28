using System;
using System.ComponentModel;

namespace MinecraftBotManager.Models
{
    [Serializable]
    public class TaskVM : INotifyPropertyChanged
    {
        public Guid ID { get; private set; }
        public string Name { get; set; }
        private int value;

        public int Value
        {
            get { return value; }
            set
            {
                if (value <= MaxValue)
                {
                    this.value = value;
                    RaisePropertyChanged();
                }
            }
        }

        private void RaisePropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public int MaxValue { get; set; }

        public TaskVM(Guid iD, string name, int value, int maxValue)
        {
            ID = iD;
            Name = name;
            Value = value;
            MaxValue = maxValue;
        }

        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
