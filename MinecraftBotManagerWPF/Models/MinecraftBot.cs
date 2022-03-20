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
        private IConnectionInfo connectionInfo;

        public IConnectionInfo ConnectionInfo { set => connectionInfo = value; }

        public MinecraftBot(IConnectionInfo connectionInfo)
        {
            this.connectionInfo = connectionInfo;
        }

        public async Task StartBotAsync()
        {
            if (connectionInfo is null)
                throw new NullReferenceException(nameof(connectionInfo) + " был null");

            this.ProtocolClient = new ProtocolClient();
        }
        public async Task StopBotAsync()
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
