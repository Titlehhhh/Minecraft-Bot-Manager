using MinecraftBotManager.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MinecraftBotManager.Contracts.Services
{
    public interface IBotRepository
    {
        void Add(BotInfo bot);
        IEnumerable<BotInfo> GetAllBots();
        Task InizializeAsync();
        bool Remove(BotInfo bot);
        bool Remove(Guid id);
        Task Save();
    }
}
