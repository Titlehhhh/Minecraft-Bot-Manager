using MinecraftLibrary.API;
using MinecraftLibrary.API.IO;
using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Proxy;
using MinecraftLibrary.Client.Networking;
using ProtocolLib754.Packets.Client;
using ProtocolLib754.Packets.Server;
using System.Net.Sockets;

namespace MinecraftLibrary.Client.Service
{
    public class ServerInfoService : IServerInfoService
    {
        public async Task<ServerInfo> GetServerInfoAsync(string host, ushort port)
        {
            ServerInfo info = null;

            TcpClient tcpClient = new TcpClient(host, port);
            tcpClient.ReceiveTimeout = 30000;
            tcpClient.ReceiveBufferSize = 1024 * 1024;

            using (NetworkMinecraftStream netstream = new NetworkMinecraftStream(tcpClient.GetStream()))
            {
                MinecraftStream minecraftStream = new MinecraftStream();
                //Отправка пакета рукопожатия
                HandShakePacket handShakePacket = new HandShakePacket(HandShakeIntent.STATUS, -1, port, host);

                handShakePacket.Write(minecraftStream);
                int Packetlength = (int)minecraftStream.Length;

                netstream.Lock.Wait();
                await netstream.WriteVarIntAsync(0.GetVarIntLength() + Packetlength);
                await netstream.WriteVarIntAsync(0);
                minecraftStream.Position = 0;
                minecraftStream.CopyTo(netstream);
                netstream.Lock.Release();

                minecraftStream = new MinecraftStream();

                StatusQueryPacket queryPacket = new StatusQueryPacket();

                queryPacket.Write(minecraftStream);
                Packetlength = (int)minecraftStream.Length;

                netstream.Lock.Wait();
                await netstream.WriteVarIntAsync(0.GetVarIntLength() + Packetlength);
                await netstream.WriteVarIntAsync(0);
                minecraftStream.Position = 0;
                minecraftStream.CopyTo(netstream);
                netstream.Lock.Release();

                //Response
                int len = await netstream.ReadVarIntAsync();

                byte[] buffer = new byte[len];
                await netstream.ReadAsync(buffer.AsMemory(0, len));

                minecraftStream = new MinecraftStream(buffer);
                int id = minecraftStream.ReadVarInt();

                if(id != 0x00)
                {
                    throw new InvalidOperationException("Id неверный");
                }

                StatusResponsePacket statusResponse = new StatusResponsePacket();
                statusResponse.Read(minecraftStream);

                info = statusResponse.ServerStatusInfo;
            }
            return info;

        }



        public Task<ServerInfo> GetServerInfoAsync(string host, ushort port, ProxyInfo proxy)
        {
            throw new NotImplementedException();
        }
    }
}
