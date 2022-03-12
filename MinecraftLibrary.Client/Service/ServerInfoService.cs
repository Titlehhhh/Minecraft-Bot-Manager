using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MinecraftLibrary.API;
using MinecraftLibrary.API.Networking.Proxy;
using MinecraftLibrary.Client.Networking;

namespace MinecraftLibrary.Client.Service
{
    public class ServerInfoService : IServerInfoService
    {
        public async Task<ServerInfo> GetServerInfoAsync(string host, ushort port)
        {
           await Task.Run(() =>
            {
                TcpClientSession tcpClient = new TcpClientSession();
                tcpClient.Host = host;
                tcpClient.Port = port;
                tcpClient.Connect();

            });

        }

        public Task<ServerInfo> GetServerInfoAsync(string host, ushort port, ProxyInfo proxy)
        {
            throw new NotImplementedException();
        }
    }
}
