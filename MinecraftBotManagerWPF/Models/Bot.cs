using MinecraftLibrary.Client;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System;
using MinecraftBotManagerWPF.Enums;

namespace MinecraftBotManagerWPF.Models
{
    [Serializable]
    public class Bot : INotifyPropertyChanged, ISerializable
    {
        public event PropertyChangedEventHandler? PropertyChanged;



        public string Nickname { get; set; }


        public string Host { get; set; }

        public ushort Port { get; set; }

        private State state;

        public State BotState
        {
            get { return state; }
            private set
            {
                state = value;
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

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(Nickname), nick);
            info.AddValue(nameof(Host), host);
        }
        protected Bot(SerializationInfo info, StreamingContext context)
        {
            Nickname = info.GetString(nameof(Nickname));
            Host = info.GetString(nameof(Host));
        }
        public Bot()
        {

        }

    }
}
