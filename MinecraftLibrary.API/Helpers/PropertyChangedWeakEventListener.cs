using System;
using System.ComponentModel;

namespace MinecraftLibrary.API.Helpers
{
    internal class PropertyChangedWeakEventListener<T> : WeakEventListenerBase<T, PropertyChangedEventArgs>
        where T : class, INotifyPropertyChanged
    {
        public PropertyChangedWeakEventListener(T source, Action<T, PropertyChangedEventArgs> handler)
            : base(source, handler)
        {
            source.PropertyChanged += HandleEvent;
        }

        protected override void StopListening(T source) => source.PropertyChanged -= HandleEvent;
    }
}
