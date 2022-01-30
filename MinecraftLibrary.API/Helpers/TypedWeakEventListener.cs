using System;

namespace MinecraftLibrary.API.Helpers
{
    internal class TypedWeakEventListener<T, TArgs> : WeakEventListenerBase<T, TArgs>
        where T : class
        where TArgs : EventArgs
    {
        private readonly Action<T, EventHandler<TArgs>> _unregister;

        public TypedWeakEventListener(T source, Action<T, EventHandler<TArgs>> register, Action<T, EventHandler<TArgs>> unregister, Action<T, TArgs> handler)
            : base(source, handler)
        {
            if (register == null) { throw new ArgumentNullException(nameof(register)); }
            _unregister = unregister ?? throw new ArgumentNullException(nameof(unregister));
            register(source, HandleEvent);
        }

        protected override void StopListening(T source) => _unregister(source, HandleEvent);
    }
}
