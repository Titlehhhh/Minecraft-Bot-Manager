using MinecraftLibrary.API.Networking.Crypto;
using MinecraftLibrary.API.Networking.Events;
using MinecraftLibrary.API.Networking.Proxy;
using System;
using System.Net;
using System.Net.Sockets;

namespace MinecraftLibrary.API.Networking
{
    /// <summary>
    /// Предоставляет низкоуровневую абстракцию для работы с TCP протоколом, сжатием и AES шифрованием
    /// </summary> 
    public interface ITcpClientSession : IDisposable, INotifyConnectedAndDisconnected
    {
        #region Методы
        void Connect();
        void Disconnect();

        void EnabledEncryption(byte[] key);
        void Send(ByteBlock data);
        void Send(byte[] data);
        #endregion
        #region Свойства        
        bool IsConnected { get; }
        int CompressionThreshold { get; set; }
        IPEndPoint EndPoint { get; }        
        ProxyInfo Proxy { get; }
        bool IsProxyUsed { get; }
        bool IsEncryption { get; }
        TcpClient Tcp { get; }
        IAesStream AesStream { get; }
        #endregion
        #region События        
        event EventHandler<PacketReceivedEventArgs> DataReceivedEvent;
        event EventHandler<ByteBlock> DataSendChanged;
        event EventHandler<ByteBlock> DataSentChanged;
        event EventHandler<byte[]> EncryptionEnabledChanged;
        event EventHandler<int> ComperssionThresholdChanged;
        #endregion
    }
    


}
