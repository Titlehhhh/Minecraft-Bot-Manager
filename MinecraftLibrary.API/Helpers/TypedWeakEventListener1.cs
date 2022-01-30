using System;

namespace MinecraftLibrary.API.Helpers
{
    internal class TypedWeakEventListener<T, TArgs, THandler> : WeakEventListenerBase<T, TArgs>
        where T : class
        where TArgs : EventArgs
        where THandler : Delegate
    {
        private readonly Action<T, THandler> _unregister;

        public TypedWeakEventListener(T source, Action<T, THandler> register, Action<T, THandler> unregister, Action<T, TArgs> handler)
            : base(source, handler)
        {
            if (register == null) { throw new ArgumentNullException(nameof(register)); }
            _unregister = unregister ?? throw new ArgumentNullException(nameof(unregister));
            register(source, (THandler)Delegate.CreateDelegate(typeof(THandler), this, nameof(HandleEvent)));
        }

        protected override void StopListening(T source)
        {
            _unregister(source, (THandler)Delegate.CreateDelegate(typeof(THandler), this, nameof(HandleEvent)));
        }
    }
}
