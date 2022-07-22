using MinecraftBotManager.Core.Minecraft;
using System.Net;

namespace MinecraftBotManager.Core
{
    public struct ConnectionInfo
    {
        public string Username { get; set; }
        public string Host { get; set; }
        public ushort Port { get; set; }
        public string ServerName { get; set; }
        public ProxyInfo? Proxy { get; set; }
    }
}
