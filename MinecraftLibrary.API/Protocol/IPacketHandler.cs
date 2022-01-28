using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Protocol.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftLibrary.API.Protocol
{
    /// <summary>
    /// Предоставляет механизм управления считывание байтов и отправке
    /// Отключением/Включением обработки пакетов.
    /// </summary>
    public interface IPacketIO
    {
        IEnumerable<Type> RegisteredPakets { get; }
        ITcpClientSession Session { get; }
        void EnabledPacket<T>() where T : IPacket;
        void DisablePacket<T>() where T : IPacket;


        void SendPacket(IPacket packet);
        event EventHandler<PacketProcessed> PacketProcessedEvent;
    }
}
