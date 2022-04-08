using MinecraftBotManager.PluginContracts;
using System;

namespace MinecraftBotManagerWPF
{
    internal interface IPluginInvoker
    {
        void Invoke(Action<IPlugin> action);
    }
}
