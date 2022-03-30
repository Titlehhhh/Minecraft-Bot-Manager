using MinecraftLibrary.API;
using MinecraftLibrary.API.IO;
using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Proxy;
using ProtocolLib754.Packets.Client;
using ProtocolLib754.Packets.Server;
using System.Net.Sockets;

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
