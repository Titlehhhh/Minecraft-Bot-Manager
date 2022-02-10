using MinecraftLibrary.API.Networking.Crypto;
using MinecraftLibrary.API.Networking.Events;
using MinecraftLibrary.API.Networking.Proxy;
using System;
using System.Net;
using System.Net.Sockets;

namespace MinecraftLibrary.API.Networking
{  
    public interface ITcpClientSession : IDisposable
    {
        #region Методы
        void Connect();
        void Disconnect();
        void Send(ByteBlock data);
        void Send(byte[] data);
        #endregion
        #region Свойства        
        bool IsConnected { get; }        
        IPEndPoint EndPoint { get; }        
        ProxyInfo Proxy { get; }
        bool IsProxyUsed { get; }        
        TcpClient Tcp { get; }
        IAesStream AesStream { get; }
        #endregion
        #region События        
        event EventHandler<PacketReceivedEventArgs> DataReceivedEvent;
        event EventHandler<ByteBlock> DataSendChanged;
        event EventHandler<ByteBlock> DataSentChanged;
        event EventHandler<byte[]> EncryptionEnabledChanged;
        event EventHandler<int> ComperssionThresholdChanged;
        event EventHandler<ConnectedEventArgs> Connected;
        event EventHandler<DisconnectedEventArgs> DisconnectedEvent;
        #endregion
    }
    


}
