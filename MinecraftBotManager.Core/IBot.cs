using MinecraftBotManager.Core.Models;

namespace MinecraftBotManager.Core
{
    public interface IBot : IDisposable
    {
        void AddObserver(IBotObserver observer);



        void Start(BotInfo info);
        void Stop();
    }
}
