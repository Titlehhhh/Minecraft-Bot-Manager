using MinecraftBotManager.PluginContracts;
using MinecraftLibrary;
using System;
using System.Collections.Generic;

namespace MinecraftBotManagerWPF
{
    internal class PluginHost : IPluginHost
    {
        private readonly MinecraftClient _client;
        public PluginHost(MinecraftClient client)
        {
            this._client = client;
        }

        public List<IPlugin> Plugins { get; private set; } = new();

        public event PluginHandler? PluginLoaded;
        public event PluginHandler? PluginUnLoaded;

        public void Add(Type Tplugin)
        {
            IPlugin plugin = (IPlugin)Activator.CreateInstance(Tplugin);

            Plugins.Add(plugin);
            plugin.Inizialize();
            plugin.Client = _client;
            this.PluginLoaded?.Invoke(this, Tplugin);
        }
        public void Remove(Type Tplugin)
        {

        }
    }

    internal class PluginInvoker : IPluginInvoker
    {
        private readonly IPluginHost _host;
        public PluginInvoker(IPluginHost host)
        {
            _host = host;
        }

        public void Invoke(Action<IPlugin> action)
        {
            foreach (IPlugin plugin in _host.Plugins.ToArray())
            {
                action(plugin);
            }
        }
    }

}
