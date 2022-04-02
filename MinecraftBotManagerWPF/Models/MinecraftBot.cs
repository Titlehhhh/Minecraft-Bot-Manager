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

        public IPluginHost PluginHost { get; private set; }


        public MinecraftBot(MinecraftClient client)
        {
            Client = client;
            PluginHost = new PluginHost(client);




        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public event PluginHandler? PluginLoaded;
        public event PluginHandler? PluginUnLoaded;


        public void Dispose()
        {
            Client.Dispose();
        }
    }
}
