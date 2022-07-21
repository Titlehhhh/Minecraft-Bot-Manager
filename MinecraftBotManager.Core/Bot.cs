using MinecraftBotManager.Core.Models;

namespace MinecraftBotManager.Core
{
    public sealed class Bot : IBot
    {
        private readonly List<IBotObserver> observers = new();

        private readonly ILogger _logger;
        public Bot(ILogger logger)
        {
            _logger = logger;
        }

        private void Notify(Action<IBotObserver> action)
        {
            lock (observers)
            {
                foreach (var obs in observers)
                {
                    action(obs);
                }
            }
        }

        public void AddObserver(IBotObserver observer)
        {
            lock (observers)
            {
                observers.Add(observer);
            }
        }

        public void Dispose()
        {
            observers.Clear();

        }

        public void Start(BotInfo info)
        {
            _logger.Info("");
        }

        public void Stop()
        {

        }
    }
}
