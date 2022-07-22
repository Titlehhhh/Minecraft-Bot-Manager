using MinecraftBotManager.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MinecraftBotManager.Contracts.Services
{
    public interface IBotRepository
    {
        void Add(ConnectionSettings bot);
        IEnumerable<ConnectionSettings> GetAllBots();
        Task InizializeAsync();
        bool Remove(ConnectionSettings bot);
        bool Remove(Guid id);
        Task Save();
    }
}
