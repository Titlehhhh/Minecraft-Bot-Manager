using MinecraftLibrary.API.Networking.IO;
using MinecraftLibrary.API.Networking.Proxy;

namespace MinecraftLibrary.API.Protocol
{
    public interface ITcpClientSession : IDisposable
    {
        void Connect();
        void Close();

        void SwitchEncryption(byte[] key);

        MinecraftStream NetStream { get; }
        int CompressionThreshold { get; set; }

        string Host { get; set; }
        int Port { get; set; }
        ProxyInfo? Proxy { get; set; }
    }

}
