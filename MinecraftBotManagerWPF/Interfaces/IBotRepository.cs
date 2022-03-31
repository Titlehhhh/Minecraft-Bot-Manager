using System.Collections.Generic;
using System.Threading.Tasks;

namespace MinecraftBotManagerWPF
{
    public interface IBotRepository
    {
        Task AddBot(BotInfo bot);
        Task RemoveBot(BotInfo bot);
        Task SaveAsync();

        IEnumerable<BotInfo> GetAllBots();

        event AddBotHandler AddBotEvent;
    }
}
