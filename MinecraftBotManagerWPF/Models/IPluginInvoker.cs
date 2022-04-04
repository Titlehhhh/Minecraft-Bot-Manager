using System;
using MinecraftBotManager.PluginContracts;

namespace MinecraftBotManagerWPF
{
    internal interface IPluginInvoker
    {
        void Invoke(Action<IPlugin> action);
    }
}
