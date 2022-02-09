using MinecraftLibrary.API.Bot;
using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Proxy;
using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.Networking.Session;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftLibrary.Core.Bot
{    
    public sealed class BotObject : IProtocolClient
    {
        public string Host { get; set; }
        public string Nickname { get; set; }
        public ushort Port { get; set; }

        public ProxyInfo? Proxy { get; set; }

        public RunState State { get; internal set; }

        private TcpClientSession session;

        public IPacketReader Reader => session;

        public IPacketWriter Writer => session;

        public ITcpClientSession Session => session;

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
        private void RaisePropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
