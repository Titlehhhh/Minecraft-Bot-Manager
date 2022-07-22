using MinecraftBotManager.Core.Models;

namespace MinecraftBotManager.Core
{
    public enum BotStatus
    {
        None,
        Inizializing,
        Running
    }
    public sealed class StatusChangedEventArgs : EventArgs
    {
        public BotStatus OldValue { get; private set; }
        public BotStatus NewValue { get; private set; }

        public StatusChangedEventArgs(BotStatus oldValue, BotStatus newValue)
        {
            OldValue = oldValue;
            NewValue = newValue;
        }
    }
    
    public interface IBot : IDisposable
    {
        BotStatus Status { get; }
        event EventHandler<StatusChangedEventArgs> StatusChanged;

        void AddObserver(IBotObserver observer);



        Task Start(ConnectionSettings info);
        void Stop();
    }
}
