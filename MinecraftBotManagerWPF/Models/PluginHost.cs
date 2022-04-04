using System;
using MinecraftLibrary;
using MinecraftBotManager.PluginContracts;
using System.Collections.Generic;

namespace MinecraftBotManagerWPF
{
    internal class PluginHost : IPluginHost, IPluginInvoker
    {
        private readonly MinecraftClient _client;
        public PluginHost(MinecraftClient client)
        {
            this._client = client;
        }

        public List<IPlugin> Plugins { get; private set; } = new();

        public event PluginHandler? PluginLoaded;
        public event PluginHandler? PluginUnLoaded;

        public void Add(IPlugin plugin)
        {
            Plugins.Add(plugin);
            plugin.Inizialize();
            plugin.Client = _client;
            this.PluginLoaded?.Invoke(this, plugin);
        }

        public void Invoke(Action<IPlugin> action)
        {
            foreach (IPlugin plugin in Plugins)
            {
                action(plugin);
            }
        }

        public void Remove(IPlugin plugin)
        {
            Plugins.Remove(plugin);
            plugin.UnLoaded();
            this.PluginUnLoaded?.Invoke(this, plugin);
        }
    }
}
