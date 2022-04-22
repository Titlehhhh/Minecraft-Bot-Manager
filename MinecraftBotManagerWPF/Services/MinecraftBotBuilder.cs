using MinecraftLibrary.API;
using MinecraftLibrary.API.Networking.Proxy;
using System;
using System.Net.Sockets;

namespace MinecraftBotManagerWPF
{
    public class MinecraftBotBuilder : IMinecraftBotBuilder 
    {
        private GameProfile gameProfile;
        private string host;
        private ushort port;
        private string proxyHost;
        private ushort proxyPort;
        private ProxyType proxyType;
        private string proxyPass;
        private string proxyLogin;
        private bool proxyAuth = false;
        private bool proxyEnabled = false;

        public MinecraftBot Build()
        {
            return new MinecraftBot(gameProfile, new TcpClient(host, port));
        }

        public void SetHost(string host, ushort port)
        {
            this.host = host;
            this.port = port;
        }

        public void SetPlugins()
        {
            throw new NotImplementedException();
        }

        public void SetProfile(GameProfile gameProfile)
        {
            if (gameProfile is null)
                throw new ArgumentNullException(nameof(gameProfile));
            this.gameProfile = gameProfile;
        }

        public void SetProxy(string host, ushort port, ProxyType type)
        {
            this.proxyEnabled = true;
            this.proxyHost = host;
            this.proxyPort = port;
            this.proxyType = type;
        }

        public void SetProxy(string host, ushort port, ProxyType type, string login, string password)
        {
            this.proxyAuth = true;
            this.proxyPass = password;
            this.proxyLogin = login;
            SetProxy(host, port, type);
        }
    }
}
