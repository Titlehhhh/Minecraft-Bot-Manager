using MinecraftLibrary.API;
using MinecraftLibrary.API.Networking.Proxy;
using MinecraftLibrary.Geometry;
using System;
using System.ComponentModel;

namespace MinecraftBotManagerWPF
{
    internal interface IMinecraftBot : INotifyPropertyChanged, IDisposable
    {
        Guid UUID { get; }
        Point3 Position { get; }
        float Yaw { get; }
        float Pitch { get; }
        Point3_Int ChunkPosition { get; }
        Point3_Int ChunkBlockPosition { get; }

        float Health { get; }

        string Nickname { get; set; }

        bool IsAuth { get; set; }
        string Password { get; set; }
        AccountType AccType { get; set; }
        string Host { get; set; }
        ushort Port { get; set; }

        bool ProxyEnabled { get; set; }
        string ProxyHost { get; set; }
        ushort ProxyPort { get; set; }
        ProxyType ProxyType { get; set; }
        string ProxyLogin { get; set; }
        string ProxyPassword { get; set; }

        void Start();
        void Stop();

        void SendMessage(string message);

    }
}
