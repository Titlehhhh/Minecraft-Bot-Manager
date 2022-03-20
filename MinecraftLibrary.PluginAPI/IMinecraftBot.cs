using MinecraftLibrary.API;
using MinecraftLibrary.API.Networking.Proxy;

namespace MinecraftLibrary.PluginAPI
{
    public interface IMinecraftBot : IDisposable
    {
        string Nickname { get; set; }
        string Host { get; set; }
        ushort Port { get; set; }
        bool IsAuth { get; set; }
        bool IsProxy { get; set; }
        ProxyInfo? Proxy { get; set; }
        AuthInfo? Auth { get; set; }

        IProtocolClient ProtocolClient { get; }



        void StartBot();
        void StopBot();
    }

}
