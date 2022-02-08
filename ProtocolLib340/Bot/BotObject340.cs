using MinecraftLibrary.API.Bot;
using MinecraftLibrary.API.Networking.Proxy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProtocolLib340.Bot
{
    public class BotObject340 : IBotObject
    {
        private RunState state;

        public string Host { get; set; }
        public ushort Port { get; set; }
        public ProxyInfo? Proxy { get; set; }

        public RunState State
        {
            get => state; internal set
            {
                state = value;
                RaizePropertyChanged();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void Connect()
        {

        }

        public void Disconect()
        {

        }

        public void Reconnect()
        {

        }
        private void RaizePropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
