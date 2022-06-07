using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftBotManager.API
{
    public interface IMinecraftBotManager
    {
        IDataService DataService { get; }
    }
}
