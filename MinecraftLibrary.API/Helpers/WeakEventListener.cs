using System;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftLibrary.API.Helpers
{    internal class WeakEventListener<T, TArgs> : WeakEventListenerBase<T, TArgs>
        where T : class
        where TArgs : EventArgs
    {
        private readonly EventInfo _eventInfo;

        public WeakEventListener(T source, string eventName, Action<T, TArgs> handler)
            : base(source, handler)
        {
            _eventInfo = source.GetType().GetEvent(eventName) ?? throw new ArgumentException("Unknown Event Name", nameof(eventName));
            if (_eventInfo.EventHandlerType == typeof(EventHandler<TArgs>))
            {
                _eventInfo.AddEventHandler(source, new EventHandler<TArgs>(HandleEvent));
            }
            else //the event type isn't just an EventHandler<> so we have to create the delegate using reflection
            {
                _eventInfo.AddEventHandler(source, Delegate.CreateDelegate(_eventInfo.EventHandlerType, this, nameof(HandleEvent)));
            }
        }

        protected override void StopListening(T source)
        {
            if (_eventInfo.EventHandlerType == typeof(EventHandler<TArgs>))
            {
                _eventInfo.RemoveEventHandler(source, new EventHandler<TArgs>(HandleEvent));
            }
            else
            {
                _eventInfo.RemoveEventHandler(source, Delegate.CreateDelegate(_eventInfo.EventHandlerType, this, nameof(HandleEvent)));
            }
        }
    }
}
