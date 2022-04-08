using MinecraftLibrary.API;
using MinecraftLibrary.API.Networking.Proxy;

namespace MinecraftLibrary.Service
{
    public class ServerInfoService : IServerInfoService
    {
        public async Task<ServerInfo> GetServerInfoAsync(string host, ushort port)
        {
            throw new NotImplementedException();
        }



        public Task<ServerInfo> GetServerInfoAsync(string host, ushort port, ProxyInfo proxy)
        {
            throw new NotImplementedException();
        }
    }
}
