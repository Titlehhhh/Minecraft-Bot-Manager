﻿using MinecraftBotManager.PluginContracts;
using System;
using System.Collections.Generic;

namespace MinecraftBotManagerWPF
{
    public delegate void PluginHandler(IPluginHost host, Type t);
    public interface IPluginHost
    {
        List<IPlugin> Plugins { get; }
        void Add(Type Tplugin);
        void Remove(Type Tplugin);
        event PluginHandler? PluginLoaded;
        event PluginHandler? PluginUnLoaded;
    }
}
