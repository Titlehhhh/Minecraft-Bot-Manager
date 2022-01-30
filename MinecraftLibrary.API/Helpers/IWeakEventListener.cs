using System;

namespace MinecraftLibrary.API.Helpers
{
    internal interface IWeakEventListener
    {
        bool IsAlive { get; }
        object Source { get; }
        Delegate Handler { get; }
        void StopListening();
    }
}
