using MinecraftLibrary.API.Networking.Proxy;
using MinecraftLibrary;
using MinecraftLibrary.API;
using System;
using System.Net.Sockets;

namespace MinecraftBotManagerWPF
{
    public class MinecraftBotBuilder
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

        public static MinecraftBotBuilder Create()
        {
            return new MinecraftBotBuilder();
        }
        public MinecraftBotBuilder SetProfile(GameProfile profile)
        {
            this.gameProfile = profile;
            return this;
        }        
        public MinecraftBotBuilder SetEndPoint(string host,ushort port)
        {
            this.host = host;
            this.port = port;
            return this;
        }
        public MinecraftBotBuilder SetProxy(string host, ushort port, ProxyType type)
        {
            this.proxyEnabled = true;
            this.proxyHost = host;
            this.proxyPort = port;
            this.proxyType = type;
            return this;
        }
        public MinecraftBotBuilder SetProxy(string host, ushort port, ProxyType type,string login,string pass)
        {
            this.proxyEnabled = true;
            this.proxyHost = host;
            this.proxyPort = port;
            this.proxyType = type;
            this.proxyAuth = true;
            this.proxyLogin = login;
            this.proxyPass = pass;
            return this;
        }

        public MinecraftBot Build()
        {
            MinecraftBot bot = new MinecraftBot(gameProfile,CreateTcp());
            
            return bot;
        }

        private TcpClient CreateTcp()
        {
            if (proxyEnabled)
            {
                //TODO
                throw new NotImplementedException();
            }
            else
            {
                return new TcpClient(host, port);
            }
        }
    }
}
