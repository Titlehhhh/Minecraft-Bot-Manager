using Starksoft.Net.Proxy;
using System.Net;


namespace MinecraftBotManager.Api.Models
{
    public class ProxyInfo
    {
        public IPEndPoint Host { get; set; }
        public ProxyType Type { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }


}
