using MinecraftLibrary.API.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using MinecraftLibrary.API.Networking.Events;

namespace MinecraftLibrary.API.Common
{

    public interface IPacketListener
    {       
        /// <summary>
        /// Вызывается когда пришел пакет
        /// </summary>
        /// <param name="session">Ссылка на сессию</param>
        /// <param name="packet">Сам пакет</param>
        public void HandlePacket(IPacketProtocol session, IPacket packet);
        /// <summary>
        /// Вызвается когда пакет пришел на сервер
        /// </summary>
        /// <param name="session">Ссылка на сессию</param>
        /// <param name="packet">Сам пакет</param>
        public void PacketSent(IPacketProtocol session, IPacket packet);
        /// <summary>
        /// Вызвается когда пакет только собирается отправиться
        /// </summary>
        /// <param name="session">Ссылка на сессию</param>
        /// <param name="packet">Сам пакет</param>
        public void PacketSend(IPacketProtocol session, IPacket packet);
        /// <summary>
        /// Вызвается когда клиент подключается к серверу
        /// </summary>
        /// <param name="session">Ссылка на сессию</param>
        /// <param name="username">Ник клиента</param>
        public void Connected(IPacketProtocol session, string username);
        public void Disconnected(IPacketProtocol session);
    }
}
