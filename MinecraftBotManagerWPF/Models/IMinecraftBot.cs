using MinecraftLibrary.API;
using MinecraftLibrary.API.Networking.Proxy;
using MinecraftLibrary.Geometry;
using System;
using System.ComponentModel;
using MinecraftLibrary;
using MinecraftBotManager.PluginContracts;
using System.Collections.Generic;

namespace MinecraftBotManagerWPF
{
    public class MinecraftBot : INotifyPropertyChanged, IDisposable
    {
        public MinecraftClient Client { get; private set; }

        public IEnumerable<IPlugin> Plugins { get; private set; }

        public void LoadPlugin(IPlugin plugin)
        {

        }
        public void UnLoadPlugin(IPlugin plugin)
        {

        }

        public MinecraftBot(MinecraftClient client)
        {
            Client = client;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void Dispose()
        {

            throw new NotImplementedException();
        }
    }
}
