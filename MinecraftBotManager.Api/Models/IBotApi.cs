using System.Net;


namespace MinecraftBotManager.Api.Models
{
    public struct ProxyInfo
    {
        public string Host { get; set; }
        public ushort Port { get; set; }
        //public ProxyType TypeProxy { get; set; }
    }

    public interface IBotApi
    {
        string Username { get; set; }

        ProxyInfo Proxy { get; set; }

        IPEndPoint Server { get; }


        string? ServerSrvName { get; }
        string? ServerDnsname { get; }



        void Start();
        void Stop();
    }
}
