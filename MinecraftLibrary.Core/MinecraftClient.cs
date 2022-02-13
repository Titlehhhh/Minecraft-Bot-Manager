using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MinecraftLibrary.Core
{

    public class MinecraftClient 
    {
        public string Nickname { get; set; }


        public event PropertyChangedEventHandler? PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
    public enum ProtocolState
    {
        HandShake,
        Login,
        Game
    }
}
