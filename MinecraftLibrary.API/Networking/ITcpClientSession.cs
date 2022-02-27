using MinecraftLibrary.API.Networking.Proxy;
using MinecraftLibrary.API.Protocol;

namespace MinecraftLibrary.API.Networking
{
    public interface ITcpClientSession
    {
        int CompressionThreshold { set; }
        string Host {  set; }        
        int Port { set; }
        ProxyInfo? Proxy {  set; }

        IPacketRepository InputPackets { set; }

        event Action<ITcpClientSession>? Connected;
        event EventHandler<DisconnectedEventArgs>? Disconnected;
        event EventHandler<PacketReceivedEventArgs>? PacketReceived;
        event EventHandler<PacketSendEventArgs>? PacketSend;
        event EventHandler<PacketSentEventArgs>? PacketSent;

        void Connect();
        void Disconnect();
        void Dispose();
        void SendPacket(IPacket packet, int id);
        void SwitchEncryption(byte[] key);
    }
}
