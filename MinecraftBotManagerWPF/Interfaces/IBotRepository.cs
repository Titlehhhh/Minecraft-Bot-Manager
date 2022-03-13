using System.Collections.Generic;
using System.Threading.Tasks;

namespace MinecraftBotManagerWPF
{
    public interface IBotRepository
    {
        Task AddBot(Bot bot);
        Task RemoveBot(Bot bot);
        Task Save();

        IEnumerable<Bot> GetAllBots();

        event AddBotHandler AddBotEvent;
    }
}
