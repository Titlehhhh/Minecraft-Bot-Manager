using MinecraftLibrary.API;
using MinecraftLibrary.API.Networking.Proxy;
using MinecraftLibrary.Geometry;
using System;
using System.ComponentModel;
using MinecraftLibrary;

namespace MinecraftBotManagerWPF
{
    public class MinecraftBot : INotifyPropertyChanged, IDisposable
    {
        public MinecraftClient Client { get; private set; }

        public MinecraftBot(MinecraftClient client)
        {

        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void Dispose()
        {

            throw new NotImplementedException();
        }
    }
}
