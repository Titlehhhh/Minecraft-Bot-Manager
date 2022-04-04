using MinecraftBotManager.PluginContracts;
using System.Collections.Generic;

namespace MinecraftBotManagerWPF
{
    internal delegate void PluginHandler(IPluginHost bot, IPlugin plugin);
    internal interface IPluginHost
    {
        List<IPlugin> Plugins { get; }
        void Add(IPlugin plugin);
        void Remove(IPlugin plugin);
        event PluginHandler? PluginLoaded;
        event PluginHandler? PluginUnLoaded;
    }
}
