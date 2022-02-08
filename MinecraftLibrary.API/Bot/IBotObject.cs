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
    public interface IBotObject : INotifyPropertyChanged
    {
        public void Connect();
        public void Reconnect();
        public void Disconect();

        public string Host { get; set; }
        public ushort Port { get; set; }
        public ProxyInfo? Proxy { get; set; }

        public ITcpClientSession Session { get; set; }
        public IPacketReader Reader { get; set; }
        public IPacketWriter Writer { get; set; }


        public SubProtocol SubProtocol { get; }
    }
    public enum SubProtocol
    {
        Handshake,
        Login,
        Game
    }
}
