using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using MinecraftLibrary.API.Networking.Proxy;
using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Protocol;

namespace MinecraftLibrary.API.Bot
{    
    public interface IProtocolClient : INotifyPropertyChanged
    {
        public void Connect();
        public void Reconnect();
        public void Disconect();
        public string Host { get; set; }
        public string Nickname { get; set; }
        public ushort Port { get; set; }
        public ProxyInfo? Proxy { get; set; }
        public RunState State { get; }
        public IPacketReader Reader { get; }
        public IPacketWriter Writer { get; }
        public ITcpClientSession Session { get; }
    }

    public enum SubProtocol
    {
        Handshake,
        Login,
        Game
    }
    public enum RunState
    {
        Init,
        Running,
        None
    }
}
