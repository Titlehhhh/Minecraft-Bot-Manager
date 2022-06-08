using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftBotManager.API
{
    public interface IBot
    {
        IMinecraftClient Client { get; }

        void Start();
    }
}
