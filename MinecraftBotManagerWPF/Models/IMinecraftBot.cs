using MinecraftLibrary.Geometry;
using System;
using System.ComponentModel;

namespace MinecraftBotManagerWPF
{
    internal interface IMinecraftBot : INotifyPropertyChanged, IDisposable
    {
        Guid UUID { get; }
        Point3 Position { get; }
        Rotation Rotation { get; }
        Point3_Int ChunkPosition { get; }
        Point3_Int ChunkBlockPosition { get; }

        float Health { get; }

        void Start();
        void Stop();

        void SendMessage(string message);

    }
}
