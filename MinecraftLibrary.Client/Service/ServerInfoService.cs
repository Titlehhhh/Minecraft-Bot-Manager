using MinecraftLibrary.API;
using MinecraftLibrary.API.Networking.Proxy;
using MinecraftLibrary.Client.Networking;

namespace MinecraftLibrary.Client.Service
{
    public class ServerInfoService : IServerInfoService
    {
        public async Task<ServerInfo> GetServerInfoAsync(string host, ushort port)
        {
            TcpClientSession tcpClient = new TcpClientSession();
            tcpClient.Host = host;
            tcpClient.Port = port;
            tcpClient.Connect();
            return null;


        }

        public Task<ServerInfo> GetServerInfoAsync(string host, ushort port, ProxyInfo proxy)
        {
            throw new NotImplementedException();
        }
    }
}
