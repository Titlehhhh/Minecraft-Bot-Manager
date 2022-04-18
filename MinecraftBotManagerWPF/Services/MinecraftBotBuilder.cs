using MinecraftLibrary.API.Networking.Proxy;

namespace MinecraftBotManagerWPF
{
    public class MinecraftBotBuilder
    {
        private string username;
        private string password;
        private bool isAuth = false;

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
        public MinecraftBotBuilder SetNickname(string nickname)
        {
            this.username = nickname;
            return this;
        }
        public MinecraftBotBuilder SetNickname(string nickname,string password)
        {
            this.isAuth = true;
            SetNickname(nickname);
            this.password = password;
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

        }
    }
}
