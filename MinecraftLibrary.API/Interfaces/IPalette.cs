using System;
using System.Collections.Generic;
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
}
