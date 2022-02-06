using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Events;
using MinecraftLibrary.API.Networking.Proxy;
using MinecraftLibrary.API.Protocol.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftLibrary.API.Protocol
{
    /// <summary>
    /// Предоставляет удобную абстракцию для работы с ITcpClientSession и пакетами
    /// </summary>
    public interface IPacketReader : IDisposable
    {
        Dictionary<Type, int> RegisteredOutputPakets { get; set; }
        Dictionary<int, Type> RegisteredInputPakets { get; set; }

        #region Пакеты от сервера


        void RegisterPacketInput(int id, Type t);
        bool UnRegisterPacketInput(int id);
        #endregion
        void RegisterPacketOutput(int id, Type t);
        bool UnRegisterPacketOutput(Type t);
        #region Методы

        void SendPacket(IPacket packet);
        #endregion




        event EventHandler<PacketProcessedEventArgs> PacketProcessedEvent;
        event EventHandler<PacketSendEventArgs> PacketSendEvent;
        event EventHandler<PacketSentEventArgs> PacketSentEvent;
    }

}
