using MinecraftLibrary.API.Networking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftLibrary.API.Protocol
{
    public interface IPacketFilter
    {
        Dictionary<int, Type> ServerPackets { get; set; }
        Dictionary<Type, int> ClientPackets { get; set; }

        void RegisterClientPacket(int id, Type value);
        void RegisterrClientPacket<TPacket>(int id) where TPacket : IPacket;

        void UnregisterClientPacket<TPacket>();
        void UnregisterClientPacket(int id);

        void RegisterServerPacket(int id, Type value);
        void RegisterServerPacket<TPacket>(int id) where TPacket : IPacket;

        void UnregisterServerPacket(Type key);
        void UnregisterServerPacket<TPacket>() where TPacket : IPacket;
        void UnregisterServerPacket(int id);


    }

}
