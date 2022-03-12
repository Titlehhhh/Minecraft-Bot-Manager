using MinecraftLibrary.API.Networking.Proxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftLibrary.API
{
    public interface IServerInfoService
    {
        Task<ServerInfo> GetServerInfoAsync(string host, ushort port);
        Task<ServerInfo> GetServerInfoAsync(string host, ushort port,ProxyInfo proxy);
    }
}
