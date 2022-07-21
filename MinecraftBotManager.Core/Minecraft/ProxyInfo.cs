
using System.Net;

namespace MinecraftBotManager.Core.Minecraft
{
    public struct ProxyInfo
    {
        public IPEndPoint Server { get; set; }
        // public ProxyType TypeProxy { get; set; }
        public string? ProxyLogin { get; set; }
        public string? ProxyPassword { get; set; }
    }
}
