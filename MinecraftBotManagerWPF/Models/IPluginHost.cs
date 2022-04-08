using MinecraftBotManager.PluginContracts;
using System;
using System.Collections.Generic;

namespace MinecraftBotManagerWPF
{
    internal delegate void PluginHandler(IPluginHost host, Type t);
    internal interface IPluginHost
    {
        List<IPlugin> Plugins { get; }
        void Add(Type Tplugin);
        void Remove(Type Tplugin);
        event PluginHandler? PluginLoaded;
        event PluginHandler? PluginUnLoaded;
    }
}
