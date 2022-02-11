using MinecraftLibrary.API.Networking.Crypto;
using MinecraftLibrary.API.Networking.Events;
using MinecraftLibrary.API.Networking.IO;
using MinecraftLibrary.API.Networking.Proxy;
using System;
using System.Net;
using System.Net.Sockets;

namespace MinecraftLibrary.API.Networking
{
    public interface IProtocolClient : IDisposable
    {
        #region Свойства
        public MinecraftStream Stream { get; }
        public bool IsConnected { get; }
        public bool IsEncrypted { get; }
        public string Host { get; set; }
        public int Port { get; set; }        
        public ProxyInfo? Proxy { get; set; }
        #endregion
        #region Методы
        void SendPacket(IPacket packet);
        void Connect();
        void Disconnect();
        void RegisterPacketInput(int id, Type t);
        void RegisterPacketOutput(int id, Type t);
        bool UnRegisterPacketInput(int id);
        bool UnRegisterPacketOutput(Type t);
        #endregion
    }


}
