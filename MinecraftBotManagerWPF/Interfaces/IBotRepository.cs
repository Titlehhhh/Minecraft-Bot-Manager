using System.Collections.Generic;
using System.Threading.Tasks;

namespace MinecraftBotManagerWPF
{
    public interface IBotRepository
    {
        Task AddBot(MinecraftBot bot);
        Task RemoveBot(MinecraftBot bot);
        Task Save();

        IEnumerable<MinecraftBot> GetAllBots();

        event AddBotHandler AddBotEvent;
    }
}
