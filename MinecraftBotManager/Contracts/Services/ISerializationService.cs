using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftBotManager.Contracts.Services
{
    public interface ISerializationService
    {
        TValue Deserialize<TValue>(string path, params object[] constructorArgs);
        void Serialize<TValue>(TValue item, string path);
    }
}
