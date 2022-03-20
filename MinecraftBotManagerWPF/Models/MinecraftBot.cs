using MinecraftLibrary;
using MinecraftLibrary.API;
using MinecraftLibrary.API.Networking.Proxy;
using MinecraftLibrary.PluginAPI;
using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace MinecraftBotManagerWPF
{

    public class MinecraftBot : IMinecraftBot
    {
        public IProtocolClient ProtocolClient { get; private set; }

        public string Nickname { get; set; }
        public string Host { get; set; }
        public bool IsAuth { get; set; }
        public bool IsProxy { get; set; }
        public ProxyInfo? Proxy { get; set; }
        public AuthInfo? Auth { get; set; }

        public MinecraftBot()
        {

        }

        public void StartBot()
        {

            this.ProtocolClient = new ProtocolClient();
            this.ProtocolClient.Nickname = this.Nickname;
            this.ProtocolClient.Host = this.Host;

            this.ProtocolClient.Connect();


        }
        public void StopBot()
        {
        }

        public void Dispose()
        {
            ProtocolClient.Dispose();
        }

        public MinecraftBot()
        {

        }

    }

    public interface IConnectionInfo
    {
        string Nickname { get; }
        string Host { get; }
        string Password { get; }

        bool IsProxy { get; }
        bool IsAuth { get; }

        ProxyInfo Proxy { get; }

    }
    public interface IBotRunner : INotifyPropertyChanged
    {





    }
}
