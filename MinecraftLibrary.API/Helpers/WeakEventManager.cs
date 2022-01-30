using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;

namespace MinecraftLibrary.API.Helpers
{
    public class WeakEventManager
    {
        private Dictionary<IWeakEventListener, Delegate> _listeners = new Dictionary<IWeakEventListener, Delegate>();

        /// <summary>
        /// Registers the given delegate as a handler for the event specified by `eventName` on the given source.
        /// </summary>
        public void AddWeakEventListener<T, TArgs>(T source, string eventName, Action<T, TArgs> handler)
            where T : class
            where TArgs : EventArgs
        {
            _listeners.Add(new WeakEventListener<T, TArgs>(source, eventName, handler), handler);
        }

        /// <summary>
        /// Registers the given delegate as a handler for the INotifyPropertyChanged.PropertyChanged event
        /// </summary>
        public void AddWeakEventListener<T>(T source, Action<T, PropertyChangedEventArgs> handler)
            where T : class, INotifyPropertyChanged
        {
            _listeners.Add(new PropertyChangedWeakEventListener<T>(source, handler), handler);
        }

        /// <summary>
        /// Registers the given delegate as a handler for the INotifyCollectionChanged.CollectionChanged event
        /// </summary>
        public void AddWeakEventListener<T>(T source, Action<T, NotifyCollectionChangedEventArgs> handler)
            where T : class, INotifyCollectionChanged
        {
            _listeners.Add(new CollectionChangedWeakEventListener<T>(source, handler), handler);
        }

        /// <summary>
        /// Registers the given delegate as a handler for the event specified by lamba expressions for registering and unregistering the event
        /// </summary>
        public void AddWeakEventListener<T, TArgs>(T source, Action<T, EventHandler<TArgs>> register, Action<T, EventHandler<TArgs>> unregister, Action<T, TArgs> handler)
            where T : class
            where TArgs : EventArgs
        {
            _listeners.Add(new TypedWeakEventListener<T, TArgs>(source, register, unregister, handler), handler);
        }

        /// <summary>
        /// Registers the given delegate as a handler for the event specified by lamba expressions for registering and unregistering the event
        /// </summary>
        public void AddWeakEventListener<T, TArgs, THandler>(T source, Action<T, THandler> register, Action<T, THandler> unregister, Action<T, TArgs> handler)
            where T : class
            where TArgs : EventArgs
            where THandler : Delegate
        {
            _listeners.Add(new TypedWeakEventListener<T, TArgs, THandler>(source, register, unregister, handler), handler);
        }

        /// <summary>
        /// Unregisters any previously registered weak event handlers on the given source object
        /// </summary>
        public void RemoveWeakEventListener<T>(T source)
            where T : class
        {
            var toRemove = new List<IWeakEventListener>();
            foreach (var listener in _listeners.Keys)
            {
                if (!listener.IsAlive)
                {
                    toRemove.Add(listener);
                }
                else if (listener.Source == source)
                {
                    listener.StopListening();
                    toRemove.Add(listener);
                }
            }
            foreach (var item in toRemove)
            {
                _listeners.Remove(item);
            }
        }

        /// <summary>
        /// Unregisters all weak event listeners that have been registered by this weak event manager instance
        /// </summary>
        public void ClearWeakEventListeners()
        {
            foreach (var listener in _listeners.Keys)
            {
                if (listener.IsAlive)
                {
                    listener.StopListening();
                }
            }
            _listeners.Clear();
        }
    }
}
