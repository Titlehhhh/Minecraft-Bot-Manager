using MinecraftLibrary.API.Networking.Proxy;

namespace MinecraftLibrary.API
{
    public interface IServerInfoService
    {
        Task<ServerInfo> GetServerInfoAsync(string host, ushort port);
        Task<ServerInfo> GetServerInfoAsync(string host, ushort port, ProxyInfo proxy);
    }
}
