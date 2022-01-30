using System;

namespace MinecraftLibrary.API.Helpers
{
    internal abstract class WeakEventListenerBase<T, TArgs> : IWeakEventListener
        where T : class
        where TArgs : EventArgs
    {
        private readonly WeakReference<T> _source;
        private readonly WeakReference<Action<T, TArgs>> _handler;

        public bool IsAlive => _handler.TryGetTarget(out var _) && _source.TryGetTarget(out var __);

        public object Source
        {
            get
            {
                if (_source.TryGetTarget(out var source))
                {
                    return source;
                }
                return null;
            }
        }

        public Delegate Handler
        {
            get
            {
                if (_handler.TryGetTarget(out var handler))
                {
                    return handler;
                }
                return null;
            }
        }

        protected WeakEventListenerBase(T source, Action<T, TArgs> handler)
        {
            _source = new WeakReference<T>(source ?? throw new ArgumentNullException(nameof(source)));
            _handler = new WeakReference<Action<T, TArgs>>(handler ?? throw new ArgumentNullException(nameof(handler)));
        }

        protected void HandleEvent(object sender, TArgs e)
        {
            if (_handler.TryGetTarget(out var handler))
            {
                handler(sender as T, e);
            }
            else
            {
                StopListening();
            }
        }

        public void StopListening()
        {
            if (_source.TryGetTarget(out var source))
            {
                StopListening(source);
            }
        }

        protected abstract void StopListening(T source);
    }
}
