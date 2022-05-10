using MinecraftBotManager.PluginContracts;
using System;

namespace MinecraftBotManagerWPF
{
    public interface IPluginInvoker
    {
        void Invoke(Action<IPlugin> action);
    }
}
