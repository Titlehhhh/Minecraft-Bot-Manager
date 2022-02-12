using MinecraftLibrary.API.Common;
using MinecraftLibrary.API.Networking.Attributes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftLibrary.API.Interfaces
{
    public interface IPalette<T>
    {
        public int[] Values { get; }
        public int Count { get; }
        public bool TryGetId(T value, out int id);
        public int GetOrAddId(T value);
        public T? GetValueFromIndex(int index);

        public IPalette<T> Clone();
    }
    public interface IPacketProvider
    {
        List<PacketInfo> GetServerPackets();
        List<PacketInfo> GetClientPackets();

        Dictionary<int,Type> GetServerPackets(PacketCategory category);
        Dictionary<Type,int> GetClientPackets(PacketCategory category);


    }

}
