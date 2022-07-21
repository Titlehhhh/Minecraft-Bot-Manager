using CommunityToolkit.Mvvm.ComponentModel;
using System;


namespace MinecraftBotManager.ViewModels
{
    public abstract class NotificationBase<T> : ObservableObject where T : class
    {
        protected T This;

        public static implicit operator T(NotificationBase<T> thing) { return thing.This; }

        public NotificationBase(T thing)
        {
            ArgumentNullException.ThrowIfNull(thing, nameof(thing));
            This = thing;
        }
    }


}
