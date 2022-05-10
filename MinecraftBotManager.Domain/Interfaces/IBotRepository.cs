using System.Collections.Generic;
using System.Threading.Tasks;

namespace MinecraftBotManagerWPF
{
    public delegate void AddBotHandler(BotInfo newbot);
    public interface IBotRepository
    {
        Task InizializeAsync();

        Task AddBot(BotInfo bot);
        Task RemoveBot(BotInfo bot);
        Task SaveAsync();

        IEnumerable<BotInfo> GetAllBots();

        event AddBotHandler AddBotEvent;
    }
}
