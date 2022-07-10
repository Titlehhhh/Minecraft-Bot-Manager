using MinecraftBotManager.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftBotManager.Contracts.Services
{
    public interface IBotRepository
    {
        void Add(BotRecord bot);
        IEnumerable<BotRecord> GetAllBots();
        Task InizializeAsync();
        bool Remove(BotRecord bot);
        bool Remove(Guid id);
        Task Save();
    }
}
